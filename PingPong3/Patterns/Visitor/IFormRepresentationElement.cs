using PingPong3.Patterns.Bridge;

namespace PingPong3.Patterns.Visitor
{
    public interface IFormRepresentationElement
    {
        void AcceptRepresentationVisitor(IVisitorPowerUp powerUp);

        Background ReturnBackground();
    }
}
