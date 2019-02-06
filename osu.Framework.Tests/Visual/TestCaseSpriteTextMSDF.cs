// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Testing;

namespace osu.Framework.Tests.Visual
{
    public class TestCaseSpriteTextMSDF : TestCase
    {
        public TestCaseSpriteTextMSDF()
        {
            FillFlowContainer flow;

            Children = new Drawable[]
            {
                new ScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Children = new[]
                    {
                        flow = new FillFlowContainer
                        {
                            Anchor = Anchor.TopLeft,
                            AutoSizeAxes = Axes.Y,
                            RelativeSizeAxes = Axes.X,
                            Direction = FillDirection.Vertical,
                        }
                    }
                }
            };

            flow.Add(new SpriteText
            {
                MSDF = true,
                Font = "OpenSans-MSDF",
                Text = @"the quick red fox jumps over the lazy brown dog"
            });
            flow.Add(new SpriteText
            {
                MSDF = true,
                Font = "OpenSans-MSDF",
                Text = @"THE QUICK RED FOX JUMPS OVER THE LAZY BROWN DOG"
            });
            flow.Add(new SpriteText
            {
                MSDF = true,
                Font = "OpenSans-MSDF",
                Text = @"0123456789!@#$%^&*()_-+-[]{}.,<>;'\"
            });

            for (int i = 1; i <= 200; i++)
            {
                SpriteText text = new SpriteText
                {
                    MSDF = true,
                    Font = "OpenSans-MSDF",
                    Text = $@"Font testy at size {i}",
                    AllowMultiline = true,
                    RelativeSizeAxes = Axes.X,
                    TextSize = i
                };

                flow.Add(text);
            }

            flow.Add(new SpriteText
            {
                MSDF = true,
                Font = "OpenSans-MSDF",
                Text = $@"Font testy at size 1000",
                AllowMultiline = true,
                RelativeSizeAxes = Axes.X,
                TextSize = 1000
            });
        }
    }
}
