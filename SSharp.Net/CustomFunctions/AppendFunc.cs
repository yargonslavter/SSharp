using Scripting.SSharp.Runtime;
using Scripting.SSharp.Parser.Ast;

namespace Scripting.SSharp.CustomFunctions
{
  internal class AppendFunc : IInvokable
  {
    public static AppendFunc FunctionDefinition = new AppendFunc();
    public static string FunctionName = "AppendAst";

    private AppendFunc()
    {
    }

    #region IInvokable Members

    public bool CanInvoke()
    {
      return true;
    }

    public object Invoke(IScriptContext context, object[] args)
    {
      var node = (ScriptProg)args[0];

      //Get Prog
      var prog = node.Parent;
      while (prog != null && !(prog is ScriptProg))
        prog = prog.Parent;

      if (prog != null)
      {
        foreach (var scriptnode in node.Elements.ChildNodes)
          prog.ChildNodes[0].ChildNodes.Add(scriptnode);
      }

      return node;
    }

    #endregion
  }
}