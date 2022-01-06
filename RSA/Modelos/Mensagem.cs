using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RSA.Modelos.Chaves;
using RSA.Util;

namespace RSA.Modelos
{
	public class Mensagem
	{
		[Key]
		public Guid Id { get; init; } = Guid.NewGuid();
		public string Msg { get; set; }
		public bool Criptografada { get; set; }
		public Guid? ComumId { get; set; } = new Comum().Id;
		public Guid? PrivadaId { get; set; } = new Privada().Id;
		public Guid? PublicaId { get; set; } = new Publica().Id;
		public Comum ChaveComum { get; set; }
		public Privada ChavePrivada { get; set; }
		public Publica ChavePublica { get; set; }
		public bool ParChavesValida { get; set; }
		
		public override string ToString()
		{
			return $"ID: {Id}\nMSG: {Msg}\nCRIPTOGRAFADA: {Criptografada}\nCOMUM_ID: {ComumId}\nPRIVADA_ID: {PrivadaId}\nPUBLICA_ID: {PublicaId}";
		}
	}
}