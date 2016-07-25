using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;

namespace GlumEngine2D
{
    public class Shader
    {
        private int programID;

        public Shader(string vertexFileName, string fragmentFileName)
        {
            programID = GL.CreateProgram();

            if (programID == 0)
            {
                Console.WriteLine("Error creating shader: Could not generate program buffer.");
                Environment.Exit(1);
            }

            AddShader(vertexFileName, ShaderType.VertexShader);
            AddShader(fragmentFileName, ShaderType.FragmentShader);
            CompileShader();

        }

        private void AddShader(string fileName, ShaderType type)
        {
            string shader = ReadShader(fileName);
            int shaderID = GL.CreateShader(type);
            if (shaderID == 0)
            {
                Console.WriteLine("Error creating shader: Could not generate shader buffer.");
                Environment.Exit(1);
            }

            GL.ShaderSource(shaderID, shader);
            GL.CompileShader(shaderID);

            int compileStatus;
            GL.GetShader(shaderID, ShaderParameter.CompileStatus, out compileStatus);
            if (compileStatus == 0)
            {
                Console.WriteLine("Error compiling shader: Could not compile shader.");
                Console.WriteLine(GL.GetShaderInfoLog(shaderID));
                Environment.Exit(1);
            }

            GL.AttachShader(programID, shaderID);
        }

        private void CompileShader()
        {
            GL.LinkProgram(programID);
            int linkStatus;
            GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out linkStatus);
            if (linkStatus == 0)
            {
                Console.WriteLine("Erorr linking shader program: Could not link shader program!");
                Console.WriteLine(GL.GetProgramInfoLog(programID));
                Environment.Exit(1);
            }

            GL.ValidateProgram(programID);
            int validatationStatus;
            GL.GetProgram(programID, GetProgramParameterName.ValidateStatus, out validatationStatus);
            if (validatationStatus == 0)
            {
                Console.WriteLine("Erorr validating shader program: Could not validate shader program!");
                Console.WriteLine(GL.GetProgramInfoLog(programID));
                Environment.Exit(1);
            }
        }

        public void Start()
        {
            GL.UseProgram(programID);
        }

        public void Stop()
        {
            GL.UseProgram(0);
        }

        private string ReadShader(string fileName)
        {
            StringBuilder shader = new StringBuilder();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        shader.Append(line).Append("\n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            return shader.ToString();
        }
    }
}
