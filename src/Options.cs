using Menu.Remix.MixedUI;
using UnityEngine;

namespace Nuktils
{
    public static class Options
    {
        public readonly struct ResultDuo<T, U>
        {
            public readonly T one;
            public readonly U two;

            public ResultDuo(T one, U two)
            {
                this.one = one;
                this.two = two;
            }
        }

        public interface ILabeledPair
        {
            public ResultDuo<UIelement[], int> Generate(Vector2 pos);
        }

        /// <summary>
        /// A OpLabel and OpCheckbox
        /// </summary>
        public class LabeledCheckboxPair : ILabeledPair
        {
            private readonly string text;

            private readonly string description;

            private readonly FLabelAlignment align;

            private readonly Configurable<bool> configurable;

            public LabeledCheckboxPair(string text, string description, Configurable<bool> configurable, FLabelAlignment align = FLabelAlignment.Left)
            {
                this.text = text;
                this.description = description;
                this.configurable = configurable;
                this.align = align;
            }

            public ResultDuo<UIelement[], int> Generate(Vector2 pos)
            {
                var ui = new UIelement[]
                {
                    new OpLabel(new(pos.x + 10, pos.y), Vector2.zero, text, align),
                    new OpCheckBox(configurable, pos) { description = description }
                };
                return new ResultDuo<UIelement[], int>(ui, 0);
            }
        }

        /// <summary>
        /// A OpLabel and OpIntSlider
        /// </summary>
        public class LabeledIntSliderPair : ILabeledPair
        {
            private readonly string text;

            private readonly string description;

            private readonly FLabelAlignment align;

            private readonly Configurable<int> configurable;

            private readonly int sliderLength;

            public LabeledIntSliderPair(string text, string description, Configurable<int> configurable, int sliderLength, FLabelAlignment align = FLabelAlignment.Left)
            {
                this.text = text;
                this.description = description;
                this.configurable = configurable;
                this.align = align;
                this.sliderLength = sliderLength;
            }

            public ResultDuo<UIelement[], int> Generate(Vector2 pos)
            {
                var ui = new UIelement[]
                {
                    new OpLabel(new(pos.x, pos.y - 10), Vector2.zero, text, align),
                    new OpSlider(configurable, pos, sliderLength) { description = description }
                };
                return new ResultDuo<UIelement[], int>(ui, 0);
            }
        }

        /// <summary>
        /// A OpLabel and OpFloatSlider
        /// </summary>
        public class LabeledFloatSliderPair : ILabeledPair
        {
            private readonly string text;

            private readonly string description;

            private readonly FLabelAlignment align;

            private readonly Configurable<float> configurable;

            private readonly int sliderLength;

            public LabeledFloatSliderPair(string text, string description, Configurable<float> configurable, int sliderLength, FLabelAlignment align = FLabelAlignment.Left)
            {
                this.text = text;
                this.description = description;
                this.configurable = configurable;
                this.align = align;
                this.sliderLength = sliderLength;
            }

            public ResultDuo<UIelement[], int> Generate(Vector2 pos)
            {
                var ui = new UIelement[]
                {
                    new OpLabel(new(pos.x, pos.y - 10), Vector2.zero, text, align),
                    new OpFloatSlider(configurable, pos, sliderLength * 3) { description = description }
                };
                return new ResultDuo<UIelement[], int>(ui, 10);
            }
        }
    }
}
