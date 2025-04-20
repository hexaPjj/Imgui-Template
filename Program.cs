using ImGuiNET;
using ClickableTransparentOverlay;
using System;
using System.Numerics;

namespace ImguiAut
{
    public class Program : Overlay
    {
        #region win32

        #endregion

        #region variables
        int FOV = 90;
        bool AFK = false;
        #endregion

        #region customSlider
        private static Dictionary<string, float> animationProgress = new Dictionary<string, float>();
        public static int SliderInt(string label, ref int value, int min, int max)
            {
            var style = ImGui.GetStyle();

            // Initialisiere die Animation, falls nicht vorhanden
            if (!animationProgress.ContainsKey(label))
                    animationProgress[label] = (value - min) / (float)(max - min);

                // Sanfte Animation aktualisieren
                float target = (value - min) / (float)(max - min);  // Zielwert basierend auf dem aktuellen Sliderwert
                animationProgress[label] = ImGui.GetIO().DeltaTime * 6.5f * (target - animationProgress[label]) + animationProgress[label];

                // Container für Slider
                ImGui.BeginGroup();

                // Text (Label) anzeigen
                ImGui.Text(label);

                // Position für den Slider unter dem Text setzen
                var cursorPos = ImGui.GetCursorScreenPos();
                cursorPos.Y += 5; // Abstand zwischen Label und Slider

                // Breite und Dicke des Sliders definieren
                var sliderSize = new Vector2(300, 7.5f); // Breiter und dicker Slider

                // Farben
                var normalFillColor = new System.Numerics.Vector4(0.9f, 0.2f, 0.2f, 1.0f); // Weiß
                var hoverOutlineColor = new System.Numerics.Vector4(1.0f, 0.4f, 0.8f, 0.0f);  // Pink bei Hover
                var backgroundColor = new System.Numerics.Vector4(0.2f, 0.2f, 0.2f, 1.0f); // Grau

                // Zeichne den Slider-Hintergrund (Grau)
                var drawList = ImGui.GetWindowDrawList();
                var sliderRectStart = cursorPos - new Vector2(1, 1); // Start der Outline leicht außerhalb
                var sliderRectEnd = cursorPos + sliderSize + new Vector2(1, 1); // Ende der Outline leicht außerhalb
                drawList.AddRectFilled(cursorPos, cursorPos + sliderSize, ImGui.ColorConvertFloat4ToU32(backgroundColor));

                // Prüfen, ob der Slider gehobert wird
                bool isHovered = ImGui.IsItemHovered();

                // Zeichne die Outline bei Hover
                if (isHovered)
                {
                    drawList.AddRect(sliderRectStart, sliderRectEnd, ImGui.ColorConvertFloat4ToU32(hoverOutlineColor), 0, ImDrawFlags.None, 2.0f);
                }

                // Zeichne den Slider-Füllstand mit sanfter Animation
                float fillWidth = animationProgress[label] * sliderSize.X;
                drawList.AddRectFilled(cursorPos, cursorPos + new Vector2(fillWidth, sliderSize.Y), ImGui.ColorConvertFloat4ToU32(normalFillColor));

                // Unsichtbarer Slider für Interaktion
                ImGui.SetCursorScreenPos(cursorPos - new Vector2(0, 10)); // Anpassung des Cursors für den unsichtbaren Bereich
                if (ImGui.InvisibleButton(label, new Vector2(sliderSize.X, 20)) || ImGui.IsItemActive())
                {
                    var mousePos = ImGui.GetMousePos().X;
                    float normalizedValue = min + ((mousePos - cursorPos.X) / sliderSize.X) * (max - min);
                    value = (int)Math.Clamp(Math.Round(normalizedValue), min, max); // Begrenzen und runden
                }

                // Aktuellen Wert rechts vom Slider anzeigen
                ImGui.SetCursorScreenPos(cursorPos + new Vector2(sliderSize.X + 10, -4));
                ImGui.Text($"{value}");

                // Cursor für nachfolgende Elemente zurücksetzen
                ImGui.SetCursorScreenPos(cursorPos + new Vector2(0, 30));

                // Beende die Gruppe
                ImGui.EndGroup();

                return value;
            }
        #endregion

        #region Style
        private void ApplyDarkStyle()
        {
            var style = ImGui.GetStyle();
            var colors = style.Colors;

            style.WindowRounding = 10f;
            style.FrameRounding = 6f;
            style.GrabRounding = 4f;
            style.FrameBorderSize = 1f;
            style.WindowBorderSize = 1f;
            style.ItemSpacing = new Vector2(10, 8);
            style.ScrollbarSize = 12f;

            style.WindowMenuButtonPosition = ImGuiDir.Right;
            style.WindowTitleAlign = new Vector2(0.50f, 0.50f);

            //text
            colors[(int)ImGuiCol.Text] = new Vector4(0.95f, 0.96f, 0.98f, 1.00f);

            //window
            colors[(int)ImGuiCol.WindowBg] = new Vector4(0.08f, 0.08f, 0.10f, 1.00f);
            colors[(int)ImGuiCol.ChildBg] = new Vector4(0.10f, 0.10f, 0.12f, 1.00f);

            //checkbox
            colors[(int)ImGuiCol.FrameBg] = new Vector4(0.12f, 0.12f, 0.15f, 1.00f); // checkbox nonhovered color
            colors[(int)ImGuiCol.FrameBgHovered] = new Vector4(0.20f, 0.20f, 0.25f, 1.00f); //hover
            colors[(int)ImGuiCol.FrameBgActive] = new Vector4(0.30f, 0.30f, 0.35f, 1.00f); //active
            style.Colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(1.0f, 1.0f, 1.0f, 1.0f); //check color

            //title
            colors[(int)ImGuiCol.TitleBg] = new Vector4(0.08f, 0.08f, 0.10f, 1.00f);
            colors[(int)ImGuiCol.TitleBgActive] = new Vector4(0.10f, 0.10f, 0.12f, 1.00f);

            //button
            colors[(int)ImGuiCol.Button] = new Vector4(0.18f, 0.18f, 0.22f, 1.00f);
            colors[(int)ImGuiCol.ButtonHovered] = new Vector4(0.28f, 0.28f, 0.35f, 1.00f);
            colors[(int)ImGuiCol.ButtonActive] = new Vector4(0.40f, 0.40f, 0.50f, 1.00f);

        }
        #endregion

        protected override void Render()
        {
            ApplyDarkStyle();
            ImGui.Begin("AutoIT - Design");

            if(ImGui.Button("Exit", new Vector2(70,30)))
            {
                Environment.Exit(0);            
            }

            ImGui.Checkbox("AFK Roblox Bot", ref AFK);
            //SliderInt("Aimbot Smoothing", ref FOV, 1, 150);
        }

        #region main
        public static void Main()
        {
            Program program = new Program();
            program.Start().Wait();
        }
        #endregion
    }
}