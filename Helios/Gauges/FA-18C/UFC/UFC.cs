﻿//  Copyright 2014 Craig Courtney
//    
//  Helios is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Helios is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GadrocsWorkshop.Helios.Gauges.FA18C
{
    using GadrocsWorkshop.Helios.Gauges.FA18C;
    using GadrocsWorkshop.Helios.Gauges;
    using GadrocsWorkshop.Helios.ComponentModel;
    using GadrocsWorkshop.Helios.Controls;
    using System;
    using System.Windows.Media;
    using System.Windows;

    [HeliosControl("Helios.FA18C.UFC", "Up Front Controller", "F/A-18C", typeof(FA18CDeviceRenderer))]
    class UFC_FA18C : FA18CDevice
    {
        private static readonly Rect SCREEN_RECT = new Rect(0, 0, 1, 1);
        private Rect _scaledScreenRect = SCREEN_RECT;
        private String _font = "MS 33558";
        //private String _font = "Franklin Gothic";
        public UFC_FA18C()
            : base("UFC", new Size(602, 470))
        {
            AddButton("EMCON", 527, 129, new Size(48, 48));
            AddButton("1", 105, 116, new Size(48, 48));
            AddButton("2", 167, 116, new Size(48, 48));
            AddButton("3", 229, 116, new Size(48, 48));
            AddButton("4", 105, 179, new Size(48, 48));
            AddButton("5", 167, 179, new Size(48, 48));
            AddButton("6", 229, 179, new Size(48, 48));
            AddButton("7", 105, 240, new Size(48, 48));
            AddButton("8", 167, 240, new Size(48, 48));
            AddButton("9", 229, 240, new Size(48, 48));
            AddButton("CLR", 105, 303, new Size(48, 48));
            AddButton("0", 167, 303, new Size(48, 48));
            AddButton("ENT", 229, 303, new Size(48, 48));
            AddButton("AP", 125, 400, new Size(40, 40));
            AddButton("IFF", 176, 400, new Size(40, 40));
            AddButton("TCN", 229, 400, new Size(40, 40));
            AddButton("ILS", 284, 400, new Size(40, 40));
            AddButton("DL", 337, 400, new Size(40, 40));
            AddButton("BCN", 393, 400, new Size(40, 40));
            AddButton("ONOFF", 447, 400, new Size(40, 40));
            AddButtonIP("IP", 28, 60, new Size(40, 40));
            AddButtonIP("ODU 1", 302, 42, new Size(40, 40));
            AddButtonIP("ODU 2", 302, 107, new Size(40, 40));
            AddButtonIP("ODU 3", 302, 175, new Size(40, 40));
            AddButtonIP("ODU 4", 302, 241, new Size(40, 40));
            AddButtonIP("ODU 5", 302, 310, new Size(40, 40));
            AddThreeWayToggle("ADF", 33, 122, new Size(30, 60));

            AddPot("Display Brightness", new Point(528, 66), new Size(48, 48));
            AddPot("Radio Volume 1", new Point(25, 213), new Size(48, 48));
            AddPot("Radio Volume 2", new Point(528, 213), new Size(48, 48));
            AddEncoder("Radio 1", new Point(29, 383), new Size(75, 75));
            AddButtonIP("Radio 1 Pull", 52, 408, new Size(28, 28), false);
            AddEncoder("Radio 2", new Point(500, 383), new Size(75, 75));
            AddButtonIP("Radio 2 Pull", 523, 408, new Size(28, 28), false);

            /// adding the diplays
            AddTextDisplay("OptionCueing1", 358, 45, new Size(40, 42));
            AddTextDisplay("OptionDisplay1", 381, 45, new Size(129, 42));
            AddTextDisplay("OptionCueing2", 358, 111, new Size(40, 42));
            AddTextDisplay("OptionDisplay2", 381, 111, new Size(129, 42));
            AddTextDisplay("OptionCueing3", 358, 177, new Size(40, 42));
            AddTextDisplay("OptionDisplay3", 381, 177, new Size(129, 42));
            AddTextDisplay("OptionCueing4", 358, 244, new Size(40, 42));
            AddTextDisplay("OptionDisplay4", 381, 244, new Size(129,42));
            AddTextDisplay("OptionCueing5", 358, 310, new Size(40, 42));
            AddTextDisplay("OptionDisplay5", 381, 310, new Size(129,42));
            AddTextDisplay("ScratchPadCharacter1", 92, 35, new Size(32, 48), 30);
            AddTextDisplay("ScratchPadCharacter2", 122, 35, new Size(32, 48), 30);
            AddTextDisplay("ScratchPadNumbers", 152, 35, new Size(135, 48), 30, TextHorizontalAlignment.Right);
            AddTextDisplay("Comm1", 26, 314, new Size(41, 42), TextHorizontalAlignment.Center);
            AddTextDisplay("Comm2", 538, 309, new Size(40, 42), TextHorizontalAlignment.Center);
        }

        public override string BezelImage
        {
            get { return "{Helios}/Gauges/FA-18C/UFC/UFC Faceplate.png"; }
        }

        private void AddPot(string name, Point posn, Size size)
        {
            AddPot(name: name, 
                posn: posn, 
                size: size, 
                knobImage: "{Helios}/Images/AV-8B/Common Knob.png", 
                initialRotation: 219, 
                rotationTravel: 291, 
                minValue: 0, 
                maxValue: 1, 
                initialValue: 0, 
                stepValue: 0.1);
        }

        private void AddEncoder(string name, Point posn, Size size)
        {
            AddEncoder(
                name: name,
                size: size,
                posn: posn,
                knobImage: "{Helios}/Images/FA-18C/UFC Rotator_U.png",
                stepValue: 0.1,
                rotationStep: 5);
        }

        private void AddTextDisplay(string name, double x, double y, Size size, string testDisp)
        {
            AddTextDisplay(name, x, y, size, 32, testDisp, TextHorizontalAlignment.Left);
        }
        private void AddTextDisplay(string name, double x, double y, Size size, double baseFontsize, TextHorizontalAlignment hTextAlign)
        {
            AddTextDisplay(name, x, y, size, baseFontsize, "~",  hTextAlign);
        }
        private void AddTextDisplay(string name, double x, double y, Size size, double baseFontsize)
        {
            AddTextDisplay(name, x, y, size, baseFontsize, "~", TextHorizontalAlignment.Left);
        }
        private void AddTextDisplay(string name, double x, double y, Size size, TextHorizontalAlignment hTextAlign)
        {
            AddTextDisplay(name, x, y, size, 32, "~", hTextAlign);
        }
        private void AddTextDisplay(string name, double x, double y, Size size)
        {
            AddTextDisplay(name, x, y, size, 32, "~", TextHorizontalAlignment.Left);
        }
        private void AddTextDisplay(string name, double x, double y, Size size,double baseFontsize, string testDisp, TextHorizontalAlignment hTextAlign)
        {
            Helios.Controls.TextDisplay display = new Helios.Controls.TextDisplay
            {
                Top = y,
                Left = x,
                Width = size.Width,
                Height = size.Height,
                Name = name
            };
            // display.FontSize = 20;
            TextFormat textFormat = new TextFormat
            {
                FontFamily = new FontFamily("Hornet UFC"),
                HorizontalAlignment = hTextAlign,
                VerticalAlignment = TextVerticalAlignment.Center,
                FontSize = baseFontsize
            };
            //textFormat.FontFamily.Baseline = 0;
            textFormat.PaddingRight = 0;
            textFormat.PaddingLeft = 0;
            textFormat.PaddingTop = 0;
            textFormat.PaddingBottom = 0;
            display.TextFormat = textFormat;
            display.OnTextColor = Color.FromArgb(0xff, 0x7e, 0xde, 0x72);
            display.BackgroundColor = Color.FromArgb(0xff, 0x26, 0x3f, 0x36);
            display.UseBackground = false;
            display.TextTestValue = testDisp;
            Children.Add(display);
            AddAction(display.Actions["set.TextDisplay"], "UFC Display " + name);
        }

        private void AddButton(string name, double x, double y, Size size)
        {
            Point pos = new Point(x, y);
            AddButton(
                name: name,
                posn: pos,
                size: size,
                image: "{Helios}/Images/FA-18C/UFC Button Up " + name + ".png",
                pushedImage: "{Helios}/Images/FA-18C/UFC Button Dn " + name + ".png",
                buttonText: ""
                );
        }

        private void AddButtonIP(string name, double x, double y, Size size)
        { AddButtonIP(name, x, y, size, true); }
        private void AddButtonIP(string name, double x, double y, Size size, Boolean glyph)
        {
            Point pos = new Point(x, y);
            PushButton button = AddButton(
                name: name,
                posn: pos,
                size: size,
                image: "{Helios}/Images/Buttons/tactile-dark-round.png",
                pushedImage: "{Helios}/Images/Buttons/tactile-dark-round-in.png",
                buttonText: ""
                );

            if (glyph)
            {
                button.Glyph = PushButtonGlyph.Circle;
                button.GlyphThickness = 3;
                button.GlyphColor = Color.FromArgb(0xFF, 0xC0, 0xC0, 0xC0);
            }

        }
        private void AddIndicator(string name, double x, double y, Size size) { AddIndicator(name, x, y, size, false); }
        private void AddIndicator(string name, double x, double y, Size size, bool _vertical)
        {
            Helios.Controls.Indicator indicator = AddIndicator(
                name: name,
                pos: new Point(x, y),
                size: size,
                onImage: "{Helios}/Images/Indicators/anunciator.png",
                offImage: "{Helios}/Images/Indicators/anunciator.png",
                onTextColor: Color.FromArgb(0xff, 0x24, 0x8D, 0x22),
                offTextColor: Color.FromArgb(0xff, 0x1C, 0x1C, 0x1C),
                font: _font,
                vertical: _vertical
                );
        }

        private void AddIndicatorPushButton(string name, double x, double y, Size size)
        {
            Color onTextColor;
            if (name == "MASTER WARNING")
            {
                onTextColor = Color.FromArgb(0xff, 0xc7, 0x1e, 0x1e);
            }
            else
            {
                onTextColor = Color.FromArgb(0xff, 0xb3, 0xa2, 0x29);
            }

            AddIndicatorPushButton(
                name: name,
                pos: new Point(x, y),
                size: size,
                image: "{Helios}/Images/Indicators/indicator.png",
                pushedImage: "{Helios}/Images/Indicators/indicator-push.png",
                textColor: Color.FromArgb(0xff, 0x1C, 0x1C, 0x1C),
                onTextColor: onTextColor,
                font: _font
                );

        }
        private void AddThreeWayToggle(string name, double x, double y, Size size)
        {

            AddThreeWayToggle(
                name: name,
                pos: new Point(x, y),
                size: size,
                defaultPosition: ThreeWayToggleSwitchPosition.Two,
                switchType: ThreeWayToggleSwitchType.OnOnOn
                );
        }

        public override bool HitTest(Point location)
        {
            if (_scaledScreenRect.Contains(location))
            {
                return false;
            }

            return true;
        }

        public override void MouseDown(Point location)
        {
            // No-Op
        }

        public override void MouseDrag(Point location)
        {
            // No-Op
        }

        public override void MouseUp(Point location)
        {
            // No-Op
        }

    }
}
