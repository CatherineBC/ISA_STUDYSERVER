using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Study_LIB
{
    public class Steganography
    { 
    
        // Hides a message inside an image using the LSB technique
        public static Bitmap HideMessage(Bitmap bmp, string message)
        {
            int charIndex = 0; // Keeps track of the character index in the message
            int charValue = 0; // Stores the ASCII value of the current character in the message
            long pixelElementIndex = 0; // Keeps track of the pixel element index in the image
            int zeros = 0; // Keeps track of the number of consecutive zeros in the LSBs

            // Iterate through each pixel in the image
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    // Modify the LSBs of the red, green, and blue pixel elements
                    for (int k = 0; k < 3; k++)
                    {
                        if (pixelElementIndex % 8 == 0) // Every 8 pixel elements, we use the next character in the message
                        {
                            if (charIndex < message.Length)
                            {
                                charValue = message[charIndex++];
                            }
                            else
                            {
                                charValue = 0;
                            }
                        }

                        // Modify the LSB of the current pixel element
                        int bit = (charValue >> (zeros++)) & 1;
                        pixel = Color.FromArgb(k == 0 ? pixel.R & ~1 | bit : pixel.R,
                                               k == 1 ? pixel.G & ~1 | bit : pixel.G,
                                               k == 2 ? pixel.B & ~1 | bit : pixel.B);

                        if (zeros == 8) // We've modified all 8 LSBs of the current pixel element
                        {
                            zeros = 0;
                            bmp.SetPixel(j, i, pixel);
                        }
                        else if (pixelElementIndex % 3 == 2) // We've modified all 3 pixel elements of the current pixel
                        {
                            bmp.SetPixel(j, i, pixel);
                        }

                        pixelElementIndex++;
                    }
                }
            }

            return bmp;
        }

        // Retrieves a message hidden inside an image using the LSB technique
        public static string RetrieveMessage(Bitmap bmp)
        {
            string message = "";

            // Iterate through each pixel in the image
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color pixel = bmp.GetPixel(j, i);

                    // Retrieve the LSBs of the red, green, and blue pixel elements
                    for (int k = 0; k < 3; k++)
                    {
                        byte pixelElement = k == 0 ? pixel.R : k == 1 ? pixel.G : pixel.B;
                        message += (char)(pixelElement & 1);
                    }
                }
            }

            // Convert the binary string to ASCII
            string result = "";
            for (int i = 0; i < message.Length; i += 8)
            {
                result += (char)Convert.ToByte(message.Substring(i, 8), 2);
            }

            return result;
        }
    }

}

