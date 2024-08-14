using Menu.Remix.MixedUI;
using UnityEngine;
using static Nuktils.Utils;

namespace Nuktils
{
    /// <summary>
    /// Utilities for remix option menus
    /// </summary>
    public static class Options
    {
        /// <summary>
        /// Used for the remix option prefabs
        /// </summary>
        public interface ILabeledPair
        {
            /// <summary>
            /// Generates this class's UI elements
            /// </summary>
            /// <param name="pos"></param>
            /// <returns>A ResultDuo struct containing the generated UI elements and a vertical offset added to the elements following this one</returns>
            public ResultDuo<UIelement[], int> Generate(Vector2 pos);
        }

        /// <summary>
        /// An OpLabel and OpCheckbox
        /// </summary>
        public class LabeledCheckboxPair : ILabeledPair
        {
            private readonly string text;

            private readonly string description;

            private readonly FLabelAlignment align;

            private readonly Configurable<bool> configurable;

            /// <summary>
            /// An OpLabel and OpCheckbox
            /// </summary>
            public LabeledCheckboxPair(string text, string description, Configurable<bool> configurable, FLabelAlignment align = FLabelAlignment.Left)
            {
                this.text = text;
                this.description = description;
                this.configurable = configurable;
                this.align = align;
            }

            /// <inheritdoc/>
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
        /// An OpLabel and OpIntSlider
        /// </summary>
        public class LabeledIntSliderPair : ILabeledPair
        {
            private readonly string text;

            private readonly string description;

            private readonly FLabelAlignment align;

            private readonly Configurable<int> configurable;

            private readonly int sliderLength;

            /// <summary>
            /// An OpLabel and OpIntSlider
            /// </summary>
            public LabeledIntSliderPair(string text, string description, Configurable<int> configurable, int sliderLength, FLabelAlignment align = FLabelAlignment.Left)
            {
                this.text = text;
                this.description = description;
                this.configurable = configurable;
                this.align = align;
                this.sliderLength = sliderLength;
            }

            /// <inheritdoc/>
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
        /// An OpLabel and OpFloatSlider
        /// </summary>
        public class LabeledFloatSliderPair : ILabeledPair
        {
            private readonly string text;

            private readonly string description;

            private readonly FLabelAlignment align;

            private readonly Configurable<float> configurable;

            private readonly int sliderLength;

            /// <summary>
            /// An OpLabel and OpFloatSlider
            /// </summary>
            public LabeledFloatSliderPair(string text, string description, Configurable<float> configurable, int sliderLength, FLabelAlignment align = FLabelAlignment.Left)
            {
                this.text = text;
                this.description = description;
                this.configurable = configurable;
                this.align = align;
                this.sliderLength = sliderLength;
            }

            /// <inheritdoc/>
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
