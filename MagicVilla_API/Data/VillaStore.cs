using MagicVilla_API.Models.Dto;

namespace MagicVilla_API.Data
{
    public class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>
        {
            new VillaDto{Id=1, Name="Vista a la piscina", Occupants=3, MetersSquared=50},
            new VillaDto{Id=2, Name="Vista a la playa", Occupants=4, MetersSquared=80}
        };
    }
}
