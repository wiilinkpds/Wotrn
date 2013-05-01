using System.Collections.Generic;
using GameProjectReborn.Managers;
using GameProjectReborn.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectReborn.UI
{
    class TextBox
    {
        public bool IsSelect;
        public Rectangle Bound { get; private set; }

        private Rectangle boundWrite;
        private Color colorRect, colorText;
        private SpriteFont spritefont;
        private int nchar, nline;
        private List<string> lines;
        private int time;

        public TextBox(Vector2 position,int nbChar,int nbLine,SpriteFont sprite_font,Color colorRect, Color colorText)
        {
            time = 0;
            IsSelect = false;
            nchar = nbChar;
            nline = nbLine;
            this.colorRect = colorRect;
            this.colorText = colorText;
            spritefont = sprite_font;
            Bound = new Rectangle((int)position.X, (int)position.Y, (int)(20 + spritefont.MeasureString("_").X * nchar), (int)(20 + spritefont.MeasureString(" ").Y * nline));
            boundWrite = new Rectangle(Bound.X + 10 ,Bound.Y + 10 , Bound.Width - 20, Bound.Height - 20);
            lines = new List<string>();
            
        }

        public string Text()
        {
            string str = "";
            foreach (var line in lines)
                str += line;
            return str;
        }

        public void Write(string text)
        {
            if (lines.Count == 0)
                lines.Add(text);
            else if (lines[lines.Count - 1].Length < nchar)
                lines[lines.Count - 1] += text;
            else if (lines.Count < nline)
                lines.Add(text);
        }
        public void WriteLine(string text)
        {
            if (lines.Count < nline)
                lines.Add(text);
        }

        public void RemoveLast()
        {
            if (lines.Count > 0)
            {
                if (lines[lines.Count - 1].Length == 0)
                    lines.RemoveAt(lines.Count - 1);
                if (lines.Count > 0)
                    lines[lines.Count - 1] = lines[lines.Count - 1].Remove(lines[lines.Count - 1].Length - 1);
            }
        }

        public void RemoveAll()
        {
            lines = new List<string>();
        }

        public void Draw(UberSpriteBatch spriteBatch)
        {
            int i;
            spriteBatch.DrawUI(TexturesManager.Window,Bound,colorRect);
            for (i = 0; i < lines.Count;i++)
                spriteBatch.DrawUI(spritefont, lines[i], new Vector2(boundWrite.X, boundWrite.Y + (i * spritefont.MeasureString(lines[i]).Y)), colorText);

            if (IsSelect)
            {
                time++;
                if (time > 30)
                {
                    if (lines.Count > 0)
                        spriteBatch.DrawUI(spritefont, "|",
                                           new Vector2(boundWrite.X + spritefont.MeasureString(lines[i - 1]).X,
                                                       boundWrite.Y +
                                                       ((i - 1)*spritefont.MeasureString(lines[i - 1]).Y)),
                                           colorText);
                    else
                        spriteBatch.DrawUI(spritefont, "|", new Vector2(boundWrite.X, boundWrite.Y), colorText);
                }
                if (time > 60)
                time = 0;
            }
        }
    }
}
