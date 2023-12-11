namespace Visitor
{
    public interface IVisitor
    {
        void Visit(Druid druid);
        void Visit(Mage mage);
    }
}