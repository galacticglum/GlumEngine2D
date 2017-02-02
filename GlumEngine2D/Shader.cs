using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;
using OpenTK;

namespace GlumEngine2D
{
    public class Shader
    {
        private readonly int programID;
        private readonly Dictionary<string, int> uniforms;

        public Shader(string vertexFileName, string fragmentFileName)
        {
            programID = GL.CreateProgram();
            uniforms = new Dictionary<string, int>();

            if (programID == 0)
            {
                Console.WriteLine("Error creating shader: Could not generate program buffer.");
                Environment.Exit(1);
            }

            AddShader(vertexFileName, ShaderType.VertexShader);
            AddShader(fragmentFileName, ShaderType.FragmentShader);
            CompileShader();
        }

        ~Shader()
        {
            GL.DeleteProgram(programID);
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
        
        public void AddUniform(string uniformName)
        {
            int uniform = GetUniformLocation(uniformName);
            if (uniform == -1)
            {
                Console.WriteLine("Could not find uniform: " + uniformName + "!");
                Environment.Exit(1);
            }
            uniforms.Add(uniformName, uniform);
        } 

        private int GetUniformLocation(string uniformName)
        {
            return GL.GetUniformLocation(programID, uniformName);
        }

        #region Uniform Loading
        public void LoadInt(string uniformName, int value)
        {
            GL.Uniform1(uniforms[uniformName], value);
        }

        public void LoadFloat(string uniformName, float value)
        {
            GL.Uniform1(uniforms[uniformName], value);
        }

        public void LoadDouble(string uniformName, double value)
        {
            GL.Uniform1(uniforms[uniformName], value);
        }

        public void LoadVector(string uniformName, Vector2 value)
        {
            GL.Uniform2(uniforms[uniformName], value);
        }

        public void LoadVector(string uniformName, Vector3 value)
        {
            GL.Uniform3(uniforms[uniformName], value);
        }

        public void LoadVector(string uniformName, Vector4 value)
        {
            GL.Uniform4(uniforms[uniformName], value);
        }

        public void LoadBoolean(string uniformName, bool value) 
        {
            GL.Uniform1(uniforms[uniformName], value ? 1 : 0);
        }

        public void LoadMatrix(string uniformName, Matrix4 value)
        {
            GL.UniformMatrix4(uniforms[uniformName], true, ref value);
        }

        #endregion

        private static string ReadShader(string fileName)
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
