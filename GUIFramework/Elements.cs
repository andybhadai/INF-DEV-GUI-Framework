using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GUIFramework
{
    interface iElement
    {
        void visit(IElementVisitor ElementVisitor);
        void Draw();
    }

    interface IElementVisitor
    {
        void OnButton(Button Button);
        void onLabel(Label Label);
    }

    class ElementVisitor : IElementVisitor
    {
        public void OnButton(Button Button)
        {
            Console.WriteLine("BUTTON!");
        }

        public void onLabel(Label Label)
        {
            Label.Draw();
        }
    }

    class Label : iElement
    {
        Vector2 position;
        string text;
        SpriteBatch sprite_batch;
        SpriteFont font;

        public Label(SpriteBatch SpriteBatch, SpriteFont Font, Vector2 Position, string Text)
        {
            this.sprite_batch = SpriteBatch;
            this.font = Font;
            this.position = Position;
            this.text = Text;
        }

        public void Draw()
        {
            sprite_batch.DrawString(font, this.text, this.position, Color.Black);
        }

        public void visit(IElementVisitor ElementVisitor)
        {
            ElementVisitor.onLabel(this);
        }
    }

    class Button
    {

    }
}
