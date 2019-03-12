
<%@ WebHandler Language="C#"
    Class="ImageHandler" %>
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web;

public class ImageHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        var request = context.Request;
        var folder = context.Request.MapPath("~/assets/i/metaicon/");
        var iconFileName = request.Params["icon"];
        var font = request.Params["font"] ?? "黑体";
        var label = request.Params["label"] ?? "家庭管理";
        var fontSize = int.Parse(request.Params["fontSize"] ?? "18");
        var width = int.Parse(request.Params["width"] ?? "200");
        var height = int.Parse(request.Params["height"] ?? "174");
        var bgcolor1 = request.Params["bgcolor1"] ?? "f0f8ff";
        var bgcolor2 = request.Params["bgcolor2"] ?? "1e90ff";
        var iconcolor1 = request.Params["iconcolor1"] ?? "f0f8ff";
        var iconcolor2 = request.Params["iconcolor2"] ?? "1e90ff";
        var angle = int.Parse(request.Params["angle"] ?? "90");
        var shape = request.Params["shape"] ?? "rectangle";
        var nolabel = request.Params["nolabel"] ?? "";
        var noshadow = request.Params["noshadow"] ?? "";
        var backgroundImage = new Bitmap(width, height);

        var g = Graphics.FromImage(backgroundImage);

        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rBackground = new Rectangle(0, 0, width, height);

        var bgBrush
            = new LinearGradientBrush(rBackground, ParseColorFromArgb(bgcolor1), ParseColorFromArgb(bgcolor2), angle);
        switch (shape)
        {
            case "rectangle":
                g.FillRectangle(bgBrush, rBackground);
                break;
            case "pie":
                g.FillPie(bgBrush, rBackground, 0, 360);
                break;
            case "trirect":
                g.FillRectangle(new SolidBrush(ParseColorFromArgb(bgcolor1)), rBackground);
                var brush = new SolidBrush(ParseColorFromArgb(bgcolor2));
                Point[] points = { new Point(width, 0), new Point(0, height), new Point(width, height) };
                g.FillPolygon(brush, points);

                break;
        }


        g.DrawImage(backgroundImage, new Point(0, 0));
        //            var image1 = new Bitmap($"{folder}{bg}");
        if (!string.IsNullOrEmpty(iconFileName))
        {
            var iconPath = folder + iconFileName;
            Bitmap icon = null;
            //var image2 = new Bitmap(new Bitmap(iconPath), (int)(width * 0.45), (int)(height * 0.45));
            var iconwidth = (int)(width * 0.5);
            var iconheight = (int)(height * 0.5);

            if (File.Exists(iconPath))
            {
                icon = new Bitmap(new Bitmap(iconPath), iconwidth, iconheight);
            }
            else
            {
                var iconfont = new Font("黑体", 150);
                var iconstring = label[0].ToString();
                g.DrawString(iconstring, iconfont, new SolidBrush(GetDarkColor(ParseColorFromArgb(bgcolor2))),
                        (backgroundImage.Width - g.MeasureString(iconstring, iconfont).Width) / 2 + 8,
                        (float)(backgroundImage.Height - iconheight) / 3 + 8);
                g.DrawString(iconstring, iconfont, new SolidBrush(Color.White),
                        (backgroundImage.Width - g.MeasureString(iconstring, iconfont).Width) / 2,
                        (float)(backgroundImage.Height - iconheight) / 3);
            }

            //            var graphics = Graphics.FromImage(image1);
            var font1 = new Font(font, fontSize);
            var fontSizeF = g.MeasureString(label, font1);
            var heightrate = 2;
            if (nolabel != "nolabel" && !string.IsNullOrEmpty(label))
            {
                heightrate = 3;
                if (noshadow != "noshadow")
                {
                    g.DrawString(label, font1, new SolidBrush(GetDarkColor(ParseColorFromArgb(bgcolor2))),
                        (backgroundImage.Width - fontSizeF.Width) / 2 + 3,
                        (float)(backgroundImage.Height - iconheight) / 2 + iconheight + 3);
                }
                g.DrawString(label, font1, new SolidBrush(Color.White),
                    (backgroundImage.Width - fontSizeF.Width) / 2,
                    (float)(backgroundImage.Height - iconheight) / 2 + iconheight);
            }

            if (noshadow != "noshadow" && icon != null)
            {
                var shadow = ToGray(icon.Clone() as Bitmap, ParseColorFromArgb(bgcolor2));
                g.DrawImage(shadow,
                    new Point((backgroundImage.Width - iconwidth) / 2 + 4,
                        (backgroundImage.Height - iconheight) / heightrate + 4));
            }
            if (icon != null)
            {
                g.DrawImage(icon,
            new Point((backgroundImage.Width - iconwidth) / 2, (backgroundImage.Height - iconheight) / heightrate));
            }

        }
        PaintPNG(context, backgroundImage);
    }

    public bool IsReusable
    {
        get { return false; }
    }

    public static Bitmap ToGray(Bitmap bmp, Color c)
    {
        for (var i = 0; i < bmp.Width; i++)
        {
            for (var j = 0; j < bmp.Height; j++)
            {
                //获取该点的像素的RGB的颜色
                var color = bmp.GetPixel(i, j);
                if (color.A != 0)
                {
                    //利用公式计算灰度值
                    var gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    var newColor = GetDarkColor(c);
                    bmp.SetPixel(i, j, newColor);
                }
            }
        }
        return bmp;
    }

    private static Color GetDarkColor(Color c)
    {
        var red = Math.Max(0, c.R - 60);
        var green = Math.Max(0, c.G - 60);
        var blue = Math.Max(0, c.B - 60);
        var newColor = Color.FromArgb(red, green, blue);
        return newColor;
    }

    private static Color ParseColorFromArgb(string bgcolor1)
    {
        var hex = NumberStyles.HexNumber;
        var fromArgb = Color.FromArgb(int.Parse(bgcolor1.Substring(0, 2), hex), int.Parse(bgcolor1.Substring(2, 2), hex),
            int.Parse(bgcolor1.Substring(4, 2), hex));
        return fromArgb;
    }

    private static void PaintPNG(HttpContext context, Bitmap bitmap)
    {
        context.Response.ContentType = "image/png";
        var stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Png);
        var buffer = stream.GetBuffer();
        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        context.Response.End();
    }
}
