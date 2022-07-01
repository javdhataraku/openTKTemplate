using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTkTemplate.GLBase;
using OpenTkTemplate.GLBase.Shaders;

namespace OpenTkTemplate
{
    public class GameRenderer
    {
        internal GameContext gc;
        internal TextureManager textureManager = new TextureManager();
        internal Plane plane = new Plane();
        internal MainDefaultShader shader;

        public void Load()
        {
            plane.Load();

            shader = new MainDefaultShader("Shaders/shader.vert", "Shaders/shader.frag");
            shader.Load();

        }

        public void Render()
        {

            foreach (Sprite item in gc.sprites)
            {
                RenderSprite(item);
            }
            RenderSprite(gc.player[0]);
        }

        private void RenderSprite(Sprite item)
        {
            plane.SetUv(item.texture.uv);
            item.texture.textureImage.Use(TextureUnit.Texture0);

            Matrix4 tran = Matrix4.CreateTranslation(item.pos);// *Matrix4.CreateScale(4,4,4);
            shader.SetModelM(tran);

            plane.Renderer();
        }

        internal void StartFrame()
        {
            plane.Bind();
            shader.Use();

            //shader.SetCamera(gc.camera);

            shader.SetCameraOrto(gc.camera,gc.player[0].pos);
            //shader.SetMatrix4("projection", Matrix4.CreateTranslation(0, 0,8));
        }
    }
}
