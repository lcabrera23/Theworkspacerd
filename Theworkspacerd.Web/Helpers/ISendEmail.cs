using Theworkspacerd.Web.Models;

namespace Theworkspacerd.Web.Helpers
{
    public interface ISendEmail
    {
        bool enviarEmailCliente(string Address, string subje, TransacionPaypal data);
        bool enviarEmailEmpresa(string subje, TransacionPaypal data);
    }
}