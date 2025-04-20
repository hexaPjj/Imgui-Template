using ImGuiNET;
using ClickableTransparentOverlay;
using System;
using System.Numerics;

namespace ImguiAut
{
    public class Program : Overlay
    {
        

        #region variables
        bool AFK = false;
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
            ImGui.Begin("Auto - Design");

            if(ImGui.Button("Exit", new Vector2(70,30)))
            {
                Environment.Exit(0);            
            }

            ImGui.Checkbox("AFK", ref AFK);
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
