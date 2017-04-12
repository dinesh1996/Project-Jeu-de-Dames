using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;







namespace ProjectDames
{
	public class Pion
	{

		//les variables 
		public enum Case { XXXX, rien, pion, test, Dame }
		Regex numSeul = new Regex(@"^[1-4]$");
		public Case type;
		public Joueur Joueur;
		public Position Pos;




		//Constructeurs
		public Pion(Case p, Position Posp)
		{
			type = p;
			Pos = Posp;

		}
		public Pion()
		{
			type = Case.XXXX;
		}

		public Pion(Case p)
		{
			type = p;


		}
		//fonctions 
		public bool DevenirDame(Pion[,] pla)
		{


			if (Joueur.Couleur == Joueur.Couleurs.Rouge)
			{
				for (int i = 0; i < 9; i++)
				{


					if (Pos == pla[9, i].Pos)
					{
						pla[9, i] = new Dame(type, Pos);
						return true;

					}
				}

			}
			else if (Joueur.Couleur == Joueur.Couleurs.Noir)
			{

				for (int i = 0; i < 9; i++)
				{


					if (Pos == pla[0, i].Pos)
					{
						pla[9, i] = new Dame(type, Pos);
						return true;


					}
				}

			}

			Console.WriteLine("Pas de Dame Possible");
			return false;

		}

		//choix du pion
		public Pion choixBouger(List<Pion> possible)
		{

			//Si on peut bouger 
			if (possible.Count > 0)
			{




				int xchoix = 0;
				int count = 0;
				int countPos = 1;
				bool sxNumber = false;



				String choix = "   ";
				String sx = "";
				bool bon = false;
				count = possible.Count;
				while (!numSeul.Match(choix).Success || !bon || !sxNumber)
				{
					Console.WriteLine("Choisiez Ou Aller");
					for (int i = 0; i < possible.Count; i++)
					{

						Console.WriteLine(countPos + "  La position :" + " [" + possible[i].Pos.x + "] " + "[" + possible[i].Pos.y + " ]");

						countPos = i + 1;
					}
					choix = Console.ReadLine();


					sx = choix[0].ToString();

					sxNumber = int.TryParse(sx, out xchoix);
					if (sxNumber)
						xchoix = int.Parse(sx);




					if (xchoix == 1)
					{
						bon = true;

						return possible[0];
					}



					if (xchoix == 2)
					{



						if (count > 1)
						{

							if (possible[1].type == Case.rien)
							{
								bon = true;
								return possible[1];
							}
						}



					}

					if (xchoix == 3)
					{

						if (count > 2)
						{

							if (possible[2].type == Case.rien)
							{
								bon = true;
								return possible[2];
							}
						}

					}

					if (xchoix == 4)
					{


						if (count > 3)
						{

							if (possible[3].type == Case.rien)
							{
								bon = true;
								return possible[3];
							}

						}
					}


				}
			}

			return new Pion();


		}


		public bool estPion()
		{
			if (Joueur == null)
				return false;
			else
				return true;
		}
		public bool EstRouge()
		{

			if (Joueur.Couleur == Joueur.Couleurs.Rouge)
				return true;

			return false;
		}

		public void Bouger(Pion Dujoueur, Pion[,] lepl)
		{


			if ((type == Case.rien))
			{
				int placex = 0;

				int placey = 0;

				placex = Pos.x;
				placey = Pos.y;

				int Dujoueurx = Dujoueur.Pos.x;
				int Dujoueury = Dujoueur.Pos.y;

				Pion Alpha = lepl[placex, placey];

				lepl[placex, placey] = lepl[Dujoueurx, Dujoueury];


				lepl[Dujoueurx, Dujoueury] = Alpha;



			}
			else
				Console.WriteLine("Impossible de deplacer le pion");

		}


		public int[] manger(Pion[,] plateau)
		{

			// avoir les possition 


			int xPion = Pos.x;
			int yPion = Pos.y;


			List<Pion> Cases = new List<Pion>();
			//List<Pion> CasesVide = new List<Pion>();


			int xfrist = xPion - 2;

			int yfrist = yPion - 2;

			int xseconde = xPion + 2;

			int yseconde = yPion + 2;
			bool isBon = false;


			// cheack values 
			// tracer les diagonal 
			// Check Les vides
			// manger les pion et deplacer 
			//List<Pion> Cases = new List<Pion>();
			//	List<Pion> CasesVide = new List<Pion>();
			//	int yp = Dujoueur.Pos.y;
			//	int xp = Dujoueur.Pos.x;
			//fait

			if ((xfrist < 9 && xfrist >= 0)
				 && (yfrist < 9 && yfrist >= 0))
			{
				if ((plateau[xfrist, yfrist].type == Pion.Case.rien))
				{

					Cases.Add(plateau[xfrist, yfrist]);
					int CasseSautx = (Pos.x + Cases[0].Pos.x) / 2;
					int CasseSauty = (Pos.y + Cases[0].Pos.y) / 2;

					if ((plateau[CasseSautx, CasseSauty].type == Case.pion)
						&& (plateau[CasseSautx, CasseSauty].Joueur != Joueur))
					{
						isBon = true;
					}
				}
			}

			//fait
			if ((xfrist < 9 && xfrist >= 0)
			  && (yseconde < 9 && yseconde >= 0))
			{

				if ((plateau[xfrist, yseconde].type == Pion.Case.rien))

				{
					Cases.Add(plateau[xfrist, yseconde]);
					int CasseSautx = (Pos.x + Cases[0].Pos.x) / 2;
					int CasseSauty = (Pos.y + Cases[0].Pos.y) / 2;

					if ((plateau[CasseSautx, CasseSauty].type == Case.pion)
						&& (plateau[CasseSautx, CasseSauty].Joueur != Joueur))
					{
						isBon = true;
					}

				}
			}

			//fait
			if ((xseconde < 9 && xseconde >= 0)
			   && (yfrist < 9 && yfrist >= 0))
			{

				if ((plateau[xseconde, yfrist].type == Pion.Case.rien))

				{
					Cases.Add(plateau[xseconde, yfrist]);
					int CasseSautx = (Pos.x + Cases[0].Pos.x) / 2;
					int CasseSauty = (Pos.y + Cases[0].Pos.y) / 2;

					if ((plateau[CasseSautx, CasseSauty].type == Case.pion)
						&& (plateau[CasseSautx, CasseSauty].Joueur != Joueur))
					{
						isBon = true;
					}

				}
			}




			if ((xseconde < 9 && xseconde >= 0)
			   && (yseconde < 9 && yseconde >= 0))
			{

				if ((plateau[xseconde, yseconde].type == Pion.Case.rien))

				{

					Cases.Add(plateau[xseconde, yseconde]);
					int CasseSautx = (Pos.x + Cases[0].Pos.x) / 2;
					int CasseSauty = (Pos.y + Cases[0].Pos.y) / 2;

					if ((plateau[CasseSautx, CasseSauty].type == Case.pion)
						&& (plateau[CasseSautx, CasseSauty].Joueur.Couleur != Joueur.Couleur))
					{
						isBon = true;
					}

				}
			}



			if (isBon)
			{


				int CasseSautx = (Pos.x + Cases[0].Pos.x) / 2;
				int CasseSauty = (Pos.y + Cases[0].Pos.y) / 2;


				int placex = 0;

				int placey = 0;

				placex = Pos.x;
				placey = Pos.y;

				int DujoueurxFuture = Cases[0].Pos.x;
				int DujoueuryFuture = Cases[0].Pos.y;

				Pion CasseDebut = plateau[placex, placey];




				Pion CasseFuture = plateau[DujoueurxFuture, DujoueuryFuture];


				plateau[placex, placey] = CasseFuture;
				plateau[CasseSautx, CasseSauty] = new Pion(Case.rien, new Position(CasseSautx, CasseSauty));

				plateau[DujoueurxFuture, DujoueuryFuture] = CasseDebut;



				int[] t2 = { DujoueurxFuture, DujoueuryFuture };
				return t2;




			}

			Console.WriteLine("On mange pas ");
			int[] t3 = { -1, -1 };
			return t3;

		}
	}
}