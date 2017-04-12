﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectDames
{

	//TODO
	//Création d'un jeu de dames en console :
	//- Création d'une classe joueur. 
	//- Création d'une classe plateau.
	//	- Chaque plateau est composé de cases pouvant être occupée par soit par un pion, soit par une Dame, soit par rien.
	//	- Création d'une fonction initialisant une partie.
	//- Création d'une classe Pion.
	//- Création d'une classe Dame dérivant de la classe Pion.
	//	- Chaque pion/Dame doit être affecté à un joueur.
	//	- Chaque pion/Dame doit pouvoir renvoyer la liste des cases atteignables.
	//- Créer une fonction permettant de bouger un pion.
	//- Créer une fonction permettant de transformer un pion en Dame.
	//- Créer une fonction permettant à un joueur de jouer son tour.
	//- Créer une fonction affichant le plateau de jeu en console.
	//- Créer une fonction lançant une partie. 
	//WPF voir apres;



	public class Joueur
	{

		public enum Couleurs { Noir, Rouge }
		public String Nom;
		public Couleurs Couleur;



		public Joueur(Couleurs couleurp)
		{
			Couleur = couleurp;
		}



	}
}
