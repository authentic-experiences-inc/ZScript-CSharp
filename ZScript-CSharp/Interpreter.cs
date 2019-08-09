using Superpower;
using Superpower.Display;
using Superpower.Model;
using Superpower.Parsers;
using Superpower.Tokenizers;

namespace AuthenticExperiences.ZScriptCSharp
{
    public class Interpreter
    {
        public void Interpret(string Input)
        {
            
        }

        public static readonly TokenListParser<ZScriptToken, int> Number =
            Token.EqualTo(ZScriptToken.Number).Apply(Numerics.IntegerInt32);
    }

    public enum ZScriptToken
    {
        [Token(Category ="keyword", Example = "class")]
        Class,
        [Token(Category ="keyword", Example ="struct")]
        Struct,
        [Token(Category = "keyword", Example = "native")]
        Native,
        //[Token(Category ="identifier", Example =":Base")]
        Inherited,
        [Token(Example = "{")]
        LBracket,
        [Token(Example = "}")]
        RBracket,
        [Token(Example = "[")]
        LSquareBracket,
        [Token(Example = "]")]
        RSquareBracket,
        [Token(Example = ":")]
        Colon,
        [Token(Example = ",")]
        Comma,
        String,
        Number,
        [Token(Category = "separator")]
        NewLine,
        Identifier,
    }

    public enum ExampleToken
    {
        [Token(Category = "keyword", Example = "MOVE")]
        Move,
        [Token(Category = "keyword", Example = "LOAD")]
        Load,
        [Token(Category = "keyword", Example = "STORE")]
        Store,
        [Token(Category = "prefix", Example = "R1", Description = "Register")]
        Register,
        [Token(Category = "keyword", Example = "123")]
        Number,
        [Token(Category = "separator")]
        NewLine,
        [Token(Category = "separator", Example = ",")]
        Comma,
        [Token(Category = "keyword", Example = "ADD")]
        Add,
        [Token(Category = "separator", Example = "#")]
        Hash,
        [Token(Category = "keyword", Example = "BRANCH")]
        BranchEqual,
        [Token(Category = "text", Example = "abc")]
        Text,
        [Token(Category = "text", Example = ":")]
        Colon,
        [Token(Category = "keyword", Example = "HALT")]
        Halt,
        [Token(Category = "operator", Example = "+")]
        Plus,
        [Token(Category = "operator", Example = "-")]
        Subtract,
        [Token(Category = "operator", Example = "*")]
        Multiply,
        [Token(Category = "keyword", Example = "BLT")]
        BranchLessThan,
        [Token(Category = "keyword", Example = "BLE")]
        BranchLessThanOrEqualTo
    }

    static class ZScriptTokenizer
    {

        static TextParser<string> NativeLine { get; } =
        from openNative in Span.EqualTo("native")
        from rest in Character.LetterOrDigit.Or(Character.EqualTo('_')).Many()
        select new string(rest);

        static TextParser<Unit> JsonStringToken { get; } =
            from open in Character.EqualTo('"')
            from content in Span.EqualTo("\\\"").Value(Unit.Value).Try()
                .Or(Character.Except('"').Value(Unit.Value))
                .IgnoreMany()
            from close in Character.EqualTo('"')
            select Unit.Value;

        static TextParser<Unit> JsonNumberToken { get; } =
            from sign in Character.EqualTo('-').OptionalOrDefault()
            from first in Character.Digit
            from rest in Character.Digit.Or(Character.In('.', 'e', 'E', '+', '-')).IgnoreMany()
            select Unit.Value;

        public static Tokenizer<ZScriptToken> Instance { get; } =
            new TokenizerBuilder<ZScriptToken>()
                .Ignore(Span.WhiteSpace)
                .Match(Character.EqualTo('{'), ZScriptToken.LBracket)
                .Match(Character.EqualTo('}'), ZScriptToken.RBracket)
                .Match(Character.EqualTo(':'), ZScriptToken.Colon)
                .Match(Character.EqualTo(','), ZScriptToken.Comma)
                .Match(Character.EqualTo('['), ZScriptToken.LSquareBracket)
                .Match(Character.EqualTo(']'), ZScriptToken.RSquareBracket)
                .Match(JsonStringToken, ZScriptToken.String)
                .Match(Numerics.Integer, ZScriptToken.Number, requireDelimiters: true)
                .Match(NativeLine, ZScriptToken.Native)
                .Match(Identifier.CStyle, ZScriptToken.Identifier, requireDelimiters: true)
                .Build();
    }
}
