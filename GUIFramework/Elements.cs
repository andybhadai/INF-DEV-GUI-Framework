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
    interface IElement
    {
        void Draw();
        void Update();
    }

    interface OptionVisitor<T, U>
    {
        U onSome(T value);
        U onNone();
    }

    public interface Option<T>
    {
        U Visit<U>(Func<U> onNone, Func<T, U> onSome);
    }

    public class Some<T> : Option<T>
    {
        T value;

        public Some(T value)
        {
            this.value = value;
        }

        public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
        {
            return onSome(value);
        }
    }

    class None<T> : Option<T>
    {
        public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
        {
            return onNone();
        }
    }

    class LambdaIOptionVisitor<T, U> : OptionVisitor<T, U>
    {
        Func<T, U> _onSome;
        Func<U> _onNone;

        public LambdaIOptionVisitor(Func<T, U> onSome, Func<U> onNone)
        {
            this._onSome = onSome;
            this._onNone = onNone;
        }

        public U onNone()
        {
            return onNone();
        }

        public U onSome(T value)
        {
            return onSome(value);
        }
    }

    public class Label : IElement
    {
        public string label_text;
        public Vector2 label_position;
        public SpriteBatch sprite_batch;
        public SpriteFont font;

        public Label(string LabelText, Vector2 LabelPosition, SpriteBatch spriteBatch, SpriteFont Font)
        {
            this.label_text = LabelText;
            this.label_position = LabelPosition;
            this.sprite_batch = spriteBatch;
            this.font = Font;
        }

        public void Draw()
        {
            sprite_batch.DrawString(this.font, this.label_text, this.label_position, Color.Black);
        }

        public void Update()
        {
            this.label_position = new Vector2(20.20f, 40.20f);
        }
    }
}
