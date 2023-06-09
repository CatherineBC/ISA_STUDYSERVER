﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace Study_LIB
{
    public class CustomPrint
    {
        private Font fontType;
        private StreamReader printToFile;
        private float marginLeft, marginRight, marginTop, marginBottom;

        public CustomPrint(Font fontType, string pathToFile, float marginLeft, float marginRight, float marginTop, float marginBottom)
        {
            FontType = fontType;
            PrintToFile = new StreamReader(pathToFile);
            MarginLeft = marginLeft;
            MarginRight = marginRight;
            MarginTop = marginTop;
            MarginBottom = marginBottom;
        }

        public Font FontType { get => fontType; set => fontType = value; }
        public StreamReader PrintToFile { get => printToFile; set => printToFile = value; }
        public float MarginLeft { get => marginLeft; set => marginLeft = value; }
        public float MarginRight { get => marginRight; set => marginRight = value; }
        public float MarginTop { get => marginTop; set => marginTop = value; }
        public float MarginBottom { get => marginBottom; set => marginBottom = value; }


        #region methods
        private void PrintText(object sender, PrintPageEventArgs e)
        {
            int maxRow = (int)((e.MarginBounds.Height - MarginTop - MarginBottom) / FontType.GetHeight(e.Graphics));
            float y = MarginTop;
            int rowNum = 0;

            string rowText = PrintToFile.ReadLine();
            while(rowNum < maxRow && rowText != null)
            {
                y = MarginTop + (rowNum * FontType.GetHeight(e.Graphics));
                e.Graphics.DrawString(rowText, FontType, Brushes.Black, MarginLeft, y);
                rowNum++;
                rowText = printToFile.ReadLine();
            }
            if(rowText != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public void SendToPrinter()
        {
            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            p.PrintPage += new PrintPageEventHandler(PrintText);
            p.Print();

            PrintToFile.Close();
        }

        #endregion
    }
}
