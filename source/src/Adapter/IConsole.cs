namespace Zbw.DesignPatterns.Adapter
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IConsole
    {
        void WriteLine(decimal value);

        void WriteLine(string value);
    }
}
