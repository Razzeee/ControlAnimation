﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ControlAnimation
{
    public static class Win32Support
    {
        /// <summary>
        /// Enumeration to be used for those Win32 function that return BOOL
        /// </summary>
        public enum Bool
        {
            False = 0,
            True
        };

        /// <summary>
        /// Enumeration for the raster operations used in BitBlt.
        /// In C++ these are actually #define. But to use these
        /// constants with C#, a new enumeration type is defined.
        /// </summary>
        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020, /* dest = source                   */
            SRCPAINT = 0x00EE0086, /* dest = source OR dest           */
            SRCAND = 0x008800C6, /* dest = source AND dest          */
            SRCINVERT = 0x00660046, /* dest = source XOR dest          */
            SRCERASE = 0x00440328, /* dest = source AND (NOT dest )   */
            NOTSRCCOPY = 0x00330008, /* dest = (NOT source)             */
            NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
            MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)     */
            MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest     */
            PATCOPY = 0x00F00021, /* dest = pattern                  */
            PATPAINT = 0x00FB0A09, /* dest = DPSnoo                   */
            PATINVERT = 0x005A0049, /* dest = pattern XOR dest         */
            DSTINVERT = 0x00550009, /* dest = (NOT dest)               */
            BLACKNESS = 0x00000042, /* dest = BLACK                    */
            WHITENESS = 0x00FF0062, /* dest = WHITE                    */
        };

        /// <summary>
        /// CreateCompatibleDC
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        /// <summary>
        /// DeleteDC
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// SelectObject
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        /// <summary>
        /// DeleteObject
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// CreateCompatibleBitmap
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hObject, int width, int height);

        /// <summary>
        /// BitBlt
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        /// <summary>
        /// StretchBlt
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool StretchBlt(
            IntPtr hdcDest,
            int nXOriginDest,
            int nYOriginDest,
            int nWidthDest,
            int nHeightDest,
            IntPtr hdcSrc,
            int nXOriginSrc,
            int nYOriginSrc,
            int nWidthSrc,
            int nHeightSrc,
            TernaryRasterOperations dwRop
            );

        /// <summary>
        /// GetClipRgn
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool GetClipRgn(IntPtr hdc, IntPtr hrgn);

        /// <summary>
        /// CreateRectRgn
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);


        /// <summary>
        /// SetStretchBltMode
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool SetStretchBltMode(IntPtr hdc, int iStretchMode);

        /// <summary>
        /// PlayEnhMetaFile
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool PlayEnhMetaFile(IntPtr hdc, IntPtr hemf, ref Rectangle lpRect);

        /// <summary>
        /// SelectClipRgn
        /// </summary>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);


        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDCEx(IntPtr ptr);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SetBkColor(IntPtr hDC, int clr);

        [DllImport("user32")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        public enum RedrawWindowFlags
        {
            RDW_INVALIDATE = 0x1,
            RDW_FRAME = 0x400
        }

    }
}
