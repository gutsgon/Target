
using System.Xml.Serialization;
namespace Target.Dto
{
    [XmlRoot("rows")]
    public class DiaValorXMLDto
    {
        [XmlElement("row")]
        public List<DiaValorDto> DiaValores { get; set; } = [];
    }

    public class DiaValorDto
    {
        [XmlElement("dia")]
        public int Dia { get; set; }
        [XmlElement("valor")]
        public decimal Valor { get; set; }
    }
}