# CodeAnalysis_bug

I am using `CSharpSyntaxTree.ParseText(text);` to parse some code to format the code and then resave it.

I encountered a very peculiar bug, where in some very rare cases, `CSharpSyntaxTree.ParseText(text).GetCompilationUnitRoot()` will cause one extra parentheses to appear where it should not.

This project is the minimal reproducable case I was able to create.

Running this project as is will take the contents of Code.txt parse them to a `SyntaxTree`, and immediately saving the contents as text into `CodeBroken.cs`

This will cause an extra parentesis to appear in line `CodeBroken.cs:234` `SecondaryStatByRarityFrom: Create((.03, .05, .07, .1, .16),`

If you were to simply change some contents of Code.txt, such as removing the comment at the top of the file, removing some logical unrelated part or simply re-ordering the contents, will cause it to write the code correctly.`SecondaryStatByRarityFrom: Create(.03, .05, .07, .1, .16),`

This happens when I updated the `Microsoft.CodeAnalysis.CSharp from 4.12.0 to 4.13.0`, This does not happen and works as expected when I downgrade back to `4.12.0`
