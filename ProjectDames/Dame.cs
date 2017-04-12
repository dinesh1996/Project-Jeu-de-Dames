using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

 
namespace ProjectDames
{
	public class Dame : Pion
	{


		public Dame(Case p, Position Posp) : base(p, Posp)
		{
			type = Case.Dame;
		}
		public Dame()
		{
			type = Case.Dame;
		}
		// j ai essayé de faire les dames, mais je pense pas qu'elles sont fonctionnelles, c'est pour ca que j ai laissé les commentaires


		//	public override Pion choixBouger(List<Pion> casse0,List<Pion> casse1,List<Pion> casse2,List<Pion> casse3) 
		//	{


		//		List<Pion> Cases0 = new List<Pion>();
		//		List<Pion> Cases1 = new List<Pion>();
		//		List<Pion> Cases2 = new List<Pion>();
		//		List<Pion> Cases3 = new List<Pion>();
		//		List<Pion> All = new List<Pion>();


		//		int ypy = DuJoueur.Pos.y;
		//		int xpx = DuJoueur.Pos.x;



		//		//++
		//		for (; ypy < 10; ypy++)
		//		{
		//			for (; xpx < 10; xpx++)
		//			{
		//				if (plateau[xpx, ypy].type == Pion.Case.rien)
		//				{


		//					Cases0.Add(plateau[xpx, ypy]);
		//				}


		//			}
		//		}


		//		//+-
		//		for (; ypy > 0; ypy--)
		//		{
		//			for (; xpx < 10; xpx++)
		//			{
		//				if (plateau[xpx, ypy].type == Pion.Case.rien)
		//				{


		//					Cases1.Add(plateau[xpx, ypy]);
		//				}


		//			}
		//		}


		//		//--
		//		for (; ypy > 0; ypy--)
		//		{
		//			for (; xpx > 0; xpx--)
		//			{
		//				if (plateau[xpx, ypy].type == Pion.Case.rien)
		//				{


		//					Cases2.Add(plateau[xpx, ypy]);
		//				}
		//			}
		//		}

		//		// -+
		//		for (; ypy < 10; ypy++)
		//		{
		//			for (; xpx > 0; xpx--)
		//			{
		//				if (plateau[xpx, ypy].type == Pion.Case.rien)
		//				{


		//					Cases3.Add(plateau[xpx, ypy]);
		//				}
		//			}
		//		}






		//}
	}
}

