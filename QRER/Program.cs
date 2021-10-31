using QRCoder;
using System;

QRCodeGenerator qrGenerator = new();
if (Uri.IsWellFormedUriString(args[0], UriKind.Absolute))
{
    QRCodeData qrCodeData = qrGenerator.CreateQrCode(args[0], QRCodeGenerator.ECCLevel.Q);
    QRCode qrCode = new(qrCodeData);
    System.Drawing.Bitmap bmp = qrCode.GetGraphic(20);
    string path = System.IO.Path.Combine(Environment.CurrentDirectory, $"QR_{DateTime.Now.Ticks}.png");
    bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
}
else
    Console.WriteLine("Specified URL not valid");