# WPFood - Projet de restauration en C#
Ce projet a été développé au Cégep de Saint-Jérôme dans le cours Projet de développement avec <a href="https://github.com/DappySorrow">@DappySorrow</a> et <a href="https://github.com/OLarue">@OLarue</a>.
Le but de ce projet était de créer un .exe en C# (Windows Presentation Foundation) et de l'utiliser sur des tablettes Microsoft dans les restaurants. Il y a plusieurs rôles pour un même programme.
- L'hôte
- Le serveur
- Le cuisinier 
- Les commentaires des clients
- La partie admin

# <h1 align="center">La connexion</h1>

Tout d'abord , l'administrateur à préalablement créé un compte pour l'utilisateur en question. Une fois fait , l'utilisateur peut se connecter avec son compte et selon son rôle la bonne page sera affichée.

![ecranAccueuil](https://github.com/PikminJaune/WPFood/assets/71794298/f7719253-a2fc-4b5a-8487-50a40b7bd2a6)

# <h1 align="center">L'hôte</h1>
L'hôte à pour but d'accueillir les clients pour les placer sur une table. Il peut aussi répondre au téléphone pour prendre des réservations.
![ecranHote](https://github.com/PikminJaune/WPFood/assets/71794298/35eeab60-3ab5-4d9c-a39c-4515f3c54f2d)
Une table rouge est une table occupée présentement.<br>
Une table verte est disponible pour des clients.<br>
Une table jaune est à nettoyer avant de remettre des clients sur celle-ci.<br>
À droite on peut remarquer le nombre total de tables et on peut on peut filtrer les tables selon l'état.<br>
Allons voir le bouton en haut à gauche pour les réservations !

![ecranHoteReservation](https://github.com/PikminJaune/WPFood/assets/71794298/d256a2cf-6d5b-4f33-aafa-9a5396ec72d5)

Donc en cliquant sur le bouton "Ajouter" un page s'ouvre avec un petit formulaire pour entrer les informations qu'on voit plus haut.

# <h1 align="center">Le serveur</h1>
Pour le serveur c'est très simple , il sélectionne la table devant laquelle il se trouve et prend la commande des clients.Une fois que la commande terminée il peut ajouter au besoin une note.Exemple: Hamburger sans tomates extra ketchup.La commande est ensuite envoyée en cuisine pour que le cuisinier puisse la préparer.À noter que chaque serveur à son propre compte pour faire les commandes.

![ecranServeur](https://github.com/PikminJaune/WPFood/assets/71794298/56dbf4ed-ccd5-480b-9c24-429c1ca98544)

Quand les clients ont terminé , il va les faire payer en sélectionnant la table , le client en question et appuyer sur "Payer".

![serveurFairePayer](https://github.com/PikminJaune/WPFood/assets/71794298/e8b8c347-f360-4945-ab10-6a662d114d48)

C'est le serveur qui met l'état a nettoyer une fois que les clients sont partis.<br>
*Le Fish N' Chips et le porc paraissent chère, mais c'est les meilleurs en ville* 😉

# <h1 align="center">Le cuisnier</h1>
Le cuisinier à une tablette en cuisine visé sur le mur pour avoir les mains libres et reçois les commandes en temps réel. Ce qui est important c'est de voir quelle table commande quoi et à quelle heure puisqu'il faut être efficace au temps de sorti des plats.Il voit donc l'heure en bas à droite de l'écran. Il y a aussi une partie "Commande aux fournisseurs" qui n'a pas été codée par manque de temps. Pour résumer cette partie, c'est le cuisinier qui s'occupe de l'inventaire dans le restaurant **ET** l'admin aussi.Le but était d'avoir une page avec tout ce qui avait en inventaire.

![ecranCuisinier](https://github.com/PikminJaune/WPFood/assets/71794298/995e9c5f-5f5f-48c3-8bc1-1df76294b875)



# <h1 align="center">Les commentaires des clients</h1>
C'est très important pour un commerce d'avoir des commentaires positifs ou négatifs pour s'améliorer. C'est pourquoi nous avons pensé à mettre des tablettes aux sorties du restaurant pour avoir de la rétroaction des clients. Voici à quoi ça ressemble.

![commentairesClients](https://github.com/PikminJaune/WPFood/assets/71794298/11aae8fe-87bb-45b0-8240-64549da2c945)

# <h1 align="center">La partie Admin</h1>
Cette partie est selon moi la plus grosse partie puisqu'elle contrôle tout.Nous avions beaucoup d'ambitions , mais peu de temps. Voici la page principale de l'admin.<br>_*Ne pas oubliez que c'est gigantesque pour les tablettes*_


![mainPageAdmin](https://github.com/PikminJaune/WPFood/assets/71794298/1a0ab1f7-62bb-4e38-9e75-95898c486662)

Les parties plus pâles ne sont pas codées , mais ont été pensées pour un ~avenir~.

Débutons avec la section tables. Très simple , une page où on voit toutes les tables du restaurant avec le nombre de personnes maximum et l'état. On peut cliquer sur "Ajouter une table" et un petit formulaire apparait pour en créer une.

![ecranAdminTables](https://github.com/PikminJaune/WPFood/assets/71794298/c1a8cc29-aee1-4f85-8d62-c2471cdbb8d4)

Par la suite , les employés dans le restaurant. En gros cette partie est touts les employés et leurs informations. Leur nom d'utilisateur et mots de passe sont créés ici. On peut soit ajouté un employé , modifier un employé en cliquant sur l'employé en question (informations ,connexion , date de naissance , etc). Lorsqu'il se connecte avec ses informations , la page qui ouvrira est selon sa fonction dans le restaurant.

![ecranAdminEmployes](https://github.com/PikminJaune/WPFood/assets/71794298/a72db076-11fb-4af6-8a95-a8264efa7071)

L'écran des statistiques. Il est très important pour un restaurant d'avoir des stats.Combien d'employé , quelle nourriture se vend le plus ou le moins , quelle journée de la semaine on vend le plus et combien compraré à la journée la moins populaire? Bref tout ce qui touche aux chiffres se trouve ici.

![ecranAdminStats](https://github.com/PikminJaune/WPFood/assets/71794298/c06a6dc9-2427-49a7-9b2d-fd3052e172b1)

Pour terminé , la partie menue . Nous avons décidé de créer des menus préfait par l'admin. Ces menus pourront se retrouver dans la section du serveur qui n'a pas été implémenté. C'est-a-dire que pour le moment , le serveur n'a qu'une seule possibilité de menu. Nous avions en tête de créer des menus selon les saisons avec des sections voici un exemple : 

 ![ecranAdminMenu](https://github.com/PikminJaune/WPFood/assets/71794298/f171020a-1cf4-4712-a235-e77b89b1b014)

Donc on voit ici , par exemple le menu #4 , qui est de type déjeuner d'hiver.On pourrait y retrouver des mets plus chauds puisque c'Est l'hiver , mais en restant dans l'optique de déjeuner. Sinon le menu #2 qui est un dîner d'automne on pourrait donc y retrouver des repas à la citrouille.

On peut aussi ajouter un menu , supprimer un menu ou le modifier. Pour créer un menu, on clique sur "Nouveau menu" , on ajoute le nom , la catégorie et la saison. Une fois créer il sera vide de repas on doit donc le sélectionner et faire "Modifier Menu" pour y ajouter des repas à l'intérieur.

![ecranAdminMenuItems](https://github.com/PikminJaune/WPFood/assets/71794298/977a7a38-d587-468e-9d99-40c88386da6f)

Ici on modifie un menu déjà existant. À gauche on voit ce que le menu contient et à droite on voit tout les repas qui existent dans le restaurant. On n'a qu'à sélectionner un article à droite , cliquer sur "Ajouter item(s) menu" et il sera ajouté. Notez bien qu'on peut ajouter plusieurs items d'un coup dans le menu et également en supprimer un ou plusieurs à la fois.Une fois terminer on clique sur "Enregistrer modifications" et le menu sera disponible avec les repas choisis.<br>
Dernier petit point pour cette section , c'est ici qu'on créer un repas pour ensuite l'ajouter , ou non , dans le menu. On clique sur "Créer item" et un page formulaire s'ouvre pour créer le nom , sa catégorie , son prix et son image pour le serveur.<br>

Chaque partie de l'application qui demande d'ajouter ou de modifier quelque chose à une vérification pour s'assure que chaque ajout est valide.<br>
Bref , j'espère que vous avez aimé regarder et lire notre projet puisque nous avons eu énormément de plaisir à le faire. 😁
