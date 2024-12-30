# Recipe manager
Ceci est un projet en C# qui utilise les notions apprises dans le cours de Programmation Orienté Objet dans le cadre du Master de Traitement Automatique de Langues. 

Il s'agit d'une applicatione en ligne de commande qui permet de charger des recettes de cuisine en format json, chercher des recettes à partir des ingredients, cateogories ou allergenes, ajouter des notes (par exemple des modifications personnelles de la recette), effacer ces notes, et sauvegarder la recette en format Markdown, HTML ou simplement l'afficer dans le terminal.

Les données proviennent de ce repository: https://github.com/dpapathanasiou/recipes?tab=readme-ov-file

Pour pouvoir bien charger le projet sur github, j'ai telechargé 10 recettes aleatoires que j'ai utilisé dans cette application et qui sont dans le dossier `recipes`. Elles ont été legerement modifiés pour separer les categories et les allergenes (pour la commande de recherche), car avant tout etait dans sous "tags". J'ai aussi crée un fichier text `recipes.txt` qui contient un index des recettes.

# Comment utiliser l'application

## 1. Charger les données

Après avoir lancé l'application avec `dotnet run` la premiere commande à lancer est `load-recipes` en donnant comme argument le dossier "recipes"
```
load-recipes ../recipes
```
Cela permet de charger les données de chaque recette à partir du fichier `recipes.txt` qui indexe les recettes presentes dans ce dossier. 
Si tout fonctionne correctement le message `10 recipes loaded` sera affiché dans le terminal. 

## 2. Lister les recettes chargées

Une fois les recettes sont chargées, pour afficher leur titres et leurs IDs on peut lancer la commande `list-recipes` sans aucun argument. 

L'output sera:
```
1. Addictive Asian Beef Slaw (Crack Slaw)
2. Baby Back Ribs
3. Bacon and Green Chili Quiche
4. Cabbage-Caraway Quiche
5. Dairy-Free Lemon Crèmes With Oat-Thyme Crumble
6. Easiest Noodle Kugel
7. Faux Tart with Instant Lemon Ginger Custard
8. Garlic Chicken and Potatoes
9. Halibut and Roasted Potatoes, Orange, and Rosemary
10. Indian Lamb Chops wih Curried Cauliflower
```
Le nombre est l'ID de la recette et le texte represente son titre. 

## 3. Afficher une certaine recette

Pour afficher la recette complete dans le terminal on peut utiliser la commande `show-recipe` en donnant comme argument son ID. 

Par exemple si on lance la commande `show-recipe 4` on obtiendra dans le terminal la recette complète de "Cabbage-Caraway Quiche". 

## 4. Ajouter des notes à une certaine recette

Si on veut ajouter des notes à une recette on peut utiliser la commande `add-note` suivie par l'ID de la recette à laquelle on veut ajouter la note et la note qu'on veut ajouter. 

Par exemple:
```
add-note 4 Use less salt
```
Si ensuite on utilise la commande `show-recipe 4` on vera qu'à la fin de la recette on aura la note 'Use less salt'.

## 5. Sauvegarder la recette avec les notes qu'on a ajoutés

Si après avoir ajouté des notes on veut sauvegarder ces notes dans le fichier JSON de la recette on peut utiliser la commande `save-recipe` en donnant comme argument l'ID de la recette qu'on veut modifier.

Par exemple: `save-recipe 4`

Si on regarde le fichier JSON qui correspond on devrait trouver les notes qu'on a ajoutées.

## 6. Eliminer toutes les notes

Si par contre on veut eliminer les notes ajoutées precedemment, on peut lancer la commande `clear-notes` suivie par l'ID de la recette dont on veut eliminer les notes. 

Par exemple: `clear-notes 4`

**Attention!** Cela ne modifie pas le fichier JSON si les notes ajoutés ont été sauvegardés. Une nouvelle sauvegarde est necessaire si on veut que le fichier JSON ne contienne pas de notes. 

## 7. Sauvegarder la recette en format markdown

Si on veut sauvegarder la recette en format markdown, avant ou après avoir ajouté / supprimé des notes, on peut le faire avec la commande `save-as-md`, suivie par l'ID de la recette qu'on souhaite sauvegarder et le chemin du fichier markdown.

Par exemple: `save-as-md 4 ../recipes/exemple.md`

On trouvera donc à ce chemin le fichier `exemple.md` qui contiendra la recette, et les notes si on les a ajouté (pas besoin que les notes soient sauvegardé dans le fichier JSON pour qu'elles soient presentes dans le markdown).

## 8. Sauvegarder la recette en format HTML

Si on veut sauvegarder la recette en format HTML, avant ou après avoir ajouté / supprimé des notes, on peut le faire avec la commande `save-as-html`, suivie par l'ID de la recette qu'on souhaite sauvegarder et le chemin du fichier HTML.

Par exemple: `save-as-html 4 ../recipes/exemple.html`

On trouvera donc à ce chemin le fichier `exemple.html` qui contiendra la recette, et les notes si on les a ajouté (pas besoin que les notes soient sauvegardé dans le fichier JSON pour qu'elles soient presentes dans le html).

## 9. Chercher une recette

Pour chercher une recette on peut utiliser la commande `search` suivie par le type de recherche et le mot clé qu'on cherche. Le type de recherche represente l'endroit ou on cherche le mot clé (par exemple parmi les titres, ingredients etc.) et le mot clé est le mot qu'on cherche à trouver. Le resultat sera l'ID et le titre de la recette qui correspond à la recherche. 
On peut chercher une recette en cherchant parmi les:
- **Titres**
	
	Pour chercher parmi les titres de recettes on peut utiliser l'argument `title` suivi par le mot-clé. 

	Par exemple: `search title cabbage` 
	
	Output: 
	```
	Found 1 recipes:
	4: Cabbage-Caraway Quiche
	```
	- **Ingredients**

	Pour trouver toutes les recettes qui contiennent un certain ingredient on peut utiliser l'argument `ingredient` suivi par le mot-clé.
	
	Par exemple `search ingredient sugar`
	
	Output:
	```
	Found 5 recipes:
	2: Baby Back Ribs
	5: Dairy-Free Lemon Crèmes With Oat-Thyme Crumble
	6: Easiest Noodle Kugel
	7: Faux Tart with Instant Lemon Ginger Custard
	8: Garlic Chicken and Potatoes
	```
- **Categories**

	Pour trouver toutes les recettes dans une certaine categorie, on peut utiliser le mot clé `category` suivi par la categorie qu'on cherche.

	Par exemple: `search category dessert`

	Output:
	```
	Found 3 recipes:
	5: Dairy-Free Lemon Crèmes With Oat-Thyme Crumble
	6: Easiest Noodle Kugel
	7: Faux Tart with Instant Lemon Ginger Custard
	```
	Autres categories possibles sont dinner, lunch, healthy
	
- **Allergenes**

	On peut aussi chercher des recettes qui correspondent à certains regimes alimentaires, par exemple "soyfree" ou "nutfree". 

	Par exemple: `search allergen glutenfree`

	Output:
	```
	Found 5 recipes:
	1: Addictive Asian Beef Slaw (Crack Slaw)
	2: Baby Back Ribs
	5: Dairy-Free Lemon Crèmes With Oat-Thyme Crumble
	8: Garlic Chicken and Potatoes
	9: Halibut and Roasted Potatoes, Orange, and Rosemary
	```
	Autres allergenes qu'on peut chercher sont soyfree, nutfree, dairyfree ou glutenfree.


- **Tags**

	Les tags sont une liste de characteristiques de la recette, utilisés pour l'indexation de la recette sur son site original. On peut chercher parmi eux, sachant qu'ils contiennent un melange d'ingredients, allergenes et categories et d'autres informations sur la recette.

	Par exemple: `search tag kid-friendly`

	Output:
	```
	Found 2 recipes:
	5: Dairy-Free Lemon Crèmes With Oat-Thyme Crumble
	6: Easiest Noodle Kugel
	```

## 10. Changer la langue de l'application

On peut changer la langue de l'application avec la commande `change-language` suivie par la langue. 

Par exemple: `change-language fr`

**Attention!** Les seules langues disponibles sont anglais (en) et français (fr). Si une autre langue est donnée comme argument, la langue par defaut sera selectionnée (l'anglais).

Une fois que la langue a été changée on peut utiliser toutes les commandes en français. Pour voir une liste complete des commandes en francais, utilisez la commande `aide`.

**Attention!** Bien que les commandes soient en français les mots clés qu'on peut utiliser ne peuvent etre qu'en anglais, car les recettes sont en anglais. 

## 11. Aide

Pour obtenir une liste complete des commandes disponibles avec une courte description utilisez la commande `help` ou `aide` si la langue de l'application est le francais. 