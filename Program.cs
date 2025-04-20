using ImGuiNET;
using ClickableTransparentOverlay;
using System;
using System.Numerics;

namespace ImguiAut
{
    public class Program : Overlay
    {
        

        #region variables
        int FOV = 90;
        float FN = 90;

        bool AFK = false;
        bool FK = false;
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
            style.Colors[(int)ImGuiCol.CheckMark] = new System.Numerics.Vector4(0.0f, 0.48f, 1.0f, 1.0f); //check color blue

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
            ImGui.Begin("Auto - Design");

            ImGui.SeparatorText("Button");
            ImGui.Button("Button 1", new Vector2(70, 30));
            ImGui.SameLine();
            ImGui.Button("Button 2", new Vector2(70, 25));
            ImGui.SameLine();
            ImGui.Button("Button 3", new Vector2(70, 20));

            ImGui.SeparatorText("Slider");
            ImGui.SliderInt("Int Slider", ref FOV, 1, 150);
            ImGui.SliderFloat("Float Slider", ref FN, 1, 150);

            ImGui.SeparatorText("Inputs");
            ImGui.InputInt("Hi Int", ref FOV);
            ImGui.InputFloat("Hi Float", ref FN);

            ImGui.SeparatorText("Text");
            ImGui.Text("Hello Text");

            ImGui.SeparatorText("Checkbox");
            ImGui.Checkbox("AFK", ref AFK);
            ImGui.SameLine();
            ImGui.Checkbox("AFK", ref FK);
            //SliderInt("Aimbot Smoothing", ref FOV, 1, 150);

            ImGui.SeparatorText("Exit");
            if(ImGui.Button("Exit",new Vector2(70,25)))
            {
                Environment.Exit(0);
            }
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
