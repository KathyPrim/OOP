
namespace CSharp
{
    abstract class NullTokenVisitor : ITokenVisitor
    {
        public virtual void Visit(ILineStartToken t) { }
        public virtual void Visit() { }
        public virtual void Visit(IKeywordToken t) { }
        /*static void Test()
        {
            new NullTokenVisitor();
        }*/
    }
}
