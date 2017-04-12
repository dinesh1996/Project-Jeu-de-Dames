using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectDames
{
	public class Plateau
	{

		Regex num = new Regex(@"^[0-9]+:+[0-9]$");
		public Pion[,] plateau = new Pion[10, 10];

		public Joueur P1 = new Joueur(Joueur.Couleurs.Rouge);
		public Joueur P2 = new Joueur(Joueur.Couleurs.Noir);


		//Creation du plateau
		public Plateau()
		{
			for (int i = 0; i < 10; i++)
			{

				for (int j = 0; j < 10; j++)
				{

					plateau[j, i] = new Pion(Pion.Case.XXXX, new Position(j, i));
				}
			}


			//Rouge

			for (int i = 1; i < 10; i += 2)
			{
				for (int j = 1; j < 5; j += 2)
				{
					plateau[j, i] = new Pion(Pion.Case.pion, new Position(j, i));

					plateau[j, i].Joueur = P1;
				}
			}

			for (int i = 0; i < 10; i += 2)
			{

				for (int j = 0; j < 4; j += 2)
				{
					plateau[j, i] = new Pion(Pion.Case.pion, new Position(j, i));
					plateau[j, i].Joueur = P1;

				}

			}

			//Noir
			for (int i = 1; i < 10; i += 2)
			{

				for (int j = 7; j < 10; j += 2)
				{
					plateau[j, i] = new Pion(Pion.Case.pion, new Position(j, i));
					plateau[j, i].Joueur = P2;

				}
			}

			for (int i = 0; i < 10; i += 2)
			{

				for (int j = 6; j < 10; j += 2)
				{
					plateau[j, i] = new Pion(Pion.Case.pion, new Position(j, i));
					plateau[j, i].Joueur = P2;

				}

			}



			for (int i = 1; i < 10; i += 2)
			{

				for (int j = 7; j < 10; j += 2)
				{
					plateau[j, i] = new Pion(Pion.Case.pion, new Position(j, i));
					plateau[j, i].Joueur = P2;


				}
			}

			//Rien 
			for (int i = 1; i < 10; i += 2)
			{

				plateau[4, i - 1] = new Pion(Pion.Case.rien, new Position(4, i - 1));



				plateau[5, i] = new Pion(Pion.Case.rien, new Position(5, i));

			}


		}

		//Cases disponibles
		public List<Pion> ToutLesCassePossible(Pion Dujoueur)
		{
			List<Pion> Cases = new List<Pion>();
			//Parties pour les dames 
			List<Pion> Cases0 = new List<Pion>();
			List<Pion> Cases1 = new List<Pion>();
			List<Pion> Cases2 = new List<Pion>();
			List<Pion> Cases3 = new List<Pion>();
			//fin dames 
			List<Pion> CasesVide = new List<Pion>();

			int yp = Dujoueur.Pos.y;
			int xp = Dujoueur.Pos.x;
			int ypy = Dujoueur.Pos.y;
			int xpx = Dujoueur.Pos.x;
			int xfrist = xp - 1;
			int yfrist = yp - 1;
			int xseconde = xp + 1;
			int yseconde = yp + 1;


			//Gestion d'un pion
			if (Dujoueur.type == Pion.Case.pion)
			{

				if ((xfrist < 9 && xfrist >= 0)
					 && (yfrist < 9 && yfrist >= 0))
				{
					if (plateau[xfrist, yfrist].type == Pion.Case.rien)
					{

						Cases.Add(new Pion(Pion.Case.rien, new Position(xfrist, yfrist)));
					}
				}


				if ((xfrist < 9 && xfrist >= 0)
				  && (yseconde < 9 && yseconde >= 0))
				{
					if (plateau[xfrist, yseconde].type == Pion.Case.rien)
					{

						Cases.Add(new Pion(Pion.Case.rien, new Position(xfrist, yseconde)));
					}
				}
				if ((xseconde < 9 && xseconde >= 0)
				   && (yfrist < 9 && yfrist >= 0))
				{
					if (plateau[xseconde, yfrist].type == Pion.Case.rien)
					{

						Cases.Add(new Pion(Pion.Case.rien, new Position(xseconde, yfrist)));
					}
				}

				if ((xseconde < 9 && xseconde >= 0)
				   && (yseconde < 9 && yseconde >= 0))
				{
					if (plateau[xseconde, yseconde].type == Pion.Case.rien)
					{

						Cases.Add(new Pion(Pion.Case.rien, new Position(xseconde, yseconde)));
					}
				}

				if (Cases.Count >= 0)
				{
					return Cases;
				}

			}
			if (Dujoueur.type == Pion.Case.Dame)

			{

				{

					//++
					for (; ypy < 10; ypy++)
					{
						for (; xpx < 10; xpx++)
						{
							if (plateau[xpx, ypy].type == Pion.Case.rien)
							{


								Cases0.Add(plateau[xpx, ypy]);
							}


						}
					}

					//+-
					for (; ypy > 0; ypy--)
					{
						for (; xpx < 10; xpx++)
						{
							if (plateau[xpx, ypy].type == Pion.Case.rien)
							{


								Cases1.Add(plateau[xpx, ypy]);
							}

						}
					}
				}

				//--
				for (; ypy > 0; ypy--)
				{
					for (; xpx > 0; xpx--)
					{
						if (plateau[xpx, ypy].type == Pion.Case.rien)
						{


							Cases2.Add(plateau[xpx, ypy]);
						}
					}
				}

				// -+
				for (; ypy < 10; ypy++)
				{
					for (; xpx > 0; xpx--)
					{
						if (plateau[xpx, ypy].type == Pion.Case.rien)
						{


							Cases3.Add(plateau[xpx, ypy]);
						}
					}
				}



			}


			Console.WriteLine("Pas de cases");
			return CasesVide;
		}

		public Pion choixPion(Joueur.Couleurs C)
		{
			int x = 0;
			int y = 0;
			String res = " ";
			String sx = "";
			String sy = "";
			bool NoPass = true;
			Pion PositionChoix;
			while ((!num.Match(res).Success) && NoPass)

			{

				Console.WriteLine("Un chiffre pour i et  y sous form 0:0 de couleur : " + C);
				res = Console.ReadLine();
			}

			sx = res[0].ToString();
			sy = res[2].ToString();
			x = int.Parse(sx);
			y = int.Parse(sy);



			PositionChoix = plateau[x, y];


			if ((plateau[x, y].type == Pion.Case.pion)
				&& (plateau[x, y].Joueur.Couleur != C))
			{
				Console.WriteLine("Mauvaises couleur ");

			}
			else if ((plateau[x, y].type == Pion.Case.pion)
				&& (plateau[x, y].Joueur.Couleur == C))
				NoPass = false;
			{

				return PositionChoix;

			}

		}

		public void Afficher()
		{


			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{

					if (plateau[i, j].Joueur == null)

						if (plateau[i, j].type == Pion.Case.rien)
							Console.Write("|[   Dispo  ]");
						else
							Console.Write("|[          ]");

					else if (plateau[i, j].Joueur.Couleur == Joueur.Couleurs.Rouge)
						Console.Write("|[   Rouge  ]");

					else if (plateau[i, j].Joueur.Couleur == Joueur.Couleurs.Noir)
						Console.Write("|[   Noir   ]");

				}
				Console.WriteLine("|");
			}
		}

	}
}
