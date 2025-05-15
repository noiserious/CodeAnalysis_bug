using Microsoft.CodeAnalysis.CSharp;

var text = File.ReadAllText("Code.txt");

var tree = CSharpSyntaxTree.ParseText(text);

File.WriteAllText("CodeBroken.cs", tree.GetCompilationUnitRoot().ToString());
