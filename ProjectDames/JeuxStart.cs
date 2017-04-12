using System;
using System.Collections.Generic;
namespace ProjectDames
{
	public class JeuxStart
	{

			public Pion PsActuel = new Pion();
			Plateau Plateau1 = new Plateau();

			public JeuxStart()
			{

				while (true)
				{


					Start();
				}
			}
			public void Start()

			{
				Console.WriteLine("Le Damier ");
				Plateau1.Afficher();


				Pion PsActuel = new Pion();
				List<Pion> LesPossible = new List<Pion>();
				Pion Vers = new Pion();

				bool estPionp = false;
				bool estRouge = false;
				int[] estManger = { -1, -1 };
				int cont = 0;
				bool isGood = false;



				while (!estRouge || !estPionp || isGood == false)
				{

					PsActuel = Plateau1.choixPion(Joueur.Couleurs.Rouge);
					estPionp = PsActuel.estPion();

					if (estPionp)
						estRouge = PsActuel.EstRouge();
					estManger = PsActuel.manger(Plateau1.plateau);
					while (estManger[0] != -1)
					{

						estManger = PsActuel.manger(Plateau1.plateau);
						if (estManger[0] != -1)
						{
							PsActuel = Plateau1.plateau[estManger[0], estManger[1]];

						}
						cont++;
					}
					isGood = true;
					if (cont == 0)
					{
						LesPossible = Plateau1.ToutLesCassePossible(PsActuel);
						if (LesPossible.Count == 0)
						{
							isGood = true;

						}
					}
				}
				estManger[0] = -1;
				estManger[1] = -1;
				isGood = false;
				Vers = PsActuel.choixBouger(LesPossible);
				Vers.Bouger(PsActuel, Plateau1.plateau);
				PsActuel.DevenirDame(Plateau1.plateau);
				Console.Clear();
				Plateau1.Afficher();
				while (estRouge || !estPionp || isGood == false)
				{

					PsActuel = Plateau1.choixPion(Joueur.Couleurs.Noir);
					estPionp = PsActuel.estPion();
					if (estPionp)
						estRouge = PsActuel.EstRouge();
					while (estManger[0] != -1)
					{

						estManger = PsActuel.manger(Plateau1.plateau);
						if (estManger[0] != -1)
						{
							PsActuel = Plateau1.plateau[estManger[0], estManger[1]];

						}
						cont++;
					}
					isGood = true;
					if (cont == 0)
					{
						LesPossible = Plateau1.ToutLesCassePossible(PsActuel);
						if (LesPossible.Count == 0)
						{
							isGood = true;

						}
					}
				}

				estManger[0] = -1;
				estManger[1] = -1;


				Vers = PsActuel.choixBouger(LesPossible);
				Vers.Bouger(PsActuel, Plateau1.plateau);
				PsActuel.DevenirDame(Plateau1.plateau);
				Console.Clear();
			}

		}

}
