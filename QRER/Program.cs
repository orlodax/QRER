﻿using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

QRCodeGenerator qrGenerator = new();
if (Uri.IsWellFormedUriString(args[0], UriKind.Absolute))
{
    QRCodeData qrCodeData = qrGenerator.CreateQrCode(args[0], QRCodeGenerator.ECCLevel.Q);
    QRCode qrCode = new(qrCodeData);
    Bitmap bmp = qrCode.GetGraphic(20);
    string path = Path.Combine(Environment.CurrentDirectory, $"QR_{DateTime.Now.Ticks}.png");
    bmp.Save(path, ImageFormat.Png);
}
else
    Console.WriteLine("Specified URL not valid");