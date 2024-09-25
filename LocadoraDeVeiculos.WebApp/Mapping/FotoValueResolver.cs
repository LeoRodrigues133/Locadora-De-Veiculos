//using AutoMapper;
//using LocadoraDeVeiculos.WebApp.Models;
//using LocadoraDeVeiculos.Dominio.ModuloVeiculos;

//namespace LocadoraDeVeiculos.WebApp.Mapping;


//public class FotoValueResolver : IValueResolver<CadastroVeiculoViewModel, Veiculo, byte[]>
//{
//    public FotoValueResolver() { }

//    public byte[] Resolve(
//        CadastroVeiculoViewModel source,
//        Veiculo destination,
//        byte[] destMember,
//        ResolutionContext context
//    )
//    {
//        using (var memoryStream = new MemoryStream())
//        {
//            source.Foto.CopyTo(memoryStream);

//            return memoryStream.ToArray();
//        }
//    }
//}