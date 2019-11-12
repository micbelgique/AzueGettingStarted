# AzureGettingStarted

Ce Azure Getting Started a été réalisé pour un séminaire donné à HEPH Condorcet Mons le 12 novembre 2019.
Il a été réalisé par [Adrien Clerbois](https://www.linkedin.com/in/aclerbois/) et [Nathan Pire](https://www.linkedin.com/in/nathanpire/)

## Les programmes à installer

### Visual Studio 2019

[Télécharger Visual Studio 2019](https://visualstudio.microsoft.com/)
Lors de l'installation, cochez ASP.NET et développement Web

### Visual Studio Code

[Télécharger Visual Studio Code](https://code.visualstudio.com/)
Après l'installation, télécharger le plugin Azure Tools dans le market [Azure Tools](https://code.visualstudio.com/docs/azure/extensions)

### Postman

Pour tester nos déploiements dans le cloud, nous utiliserons Postman!
[Télécharger Postman](https://www.getpostman.com/)

## Step by step

1. Téléchargez le code
![Télécharger le code depuis Github](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Github-Download.png)

2. Lancez Visual Studio et le projet
![Lancer Visual Studio](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/VisualStudio-Launch.jpg)

3. Lancez Visual Studio Code et ouvrez le dossier
![Lancer Visual Studio Code](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/VisualStudioCode-Launch.jpg)

4. Allez sur [Azure](portal.azure.com), nouvelle ressource et cherchez Ressource Group
![Cliquer sur Ressource Group](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-RessourceGroup-RessourceGroup.png)

5. Configurez le Ressource Group en mettant le nom et la région souhaitée
![Configure le Ressource Group](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-RessourceGroup-Configure.png)

6. Dans le Ressource Group, appuyez sur le bouton Add et chercher Computer Vision
![Chercher Computer Vision](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-ComputerVision-ComputerVision.png)

7. Ensuite, configurez Computer Vision avec le nom, la localisation, le niveau de tarification
![Configurer Computer Vision](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-ComputerVision-Configure.png)
Une fois la ressource créée, gardez de côté la clé et l'endpoint du service.

8. Dans le Ressource Group, appuyez sur le bouton Add
![Bouton Add](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Function-AddButton.png)
Ensuite, cherchez Function App
![Chercher Function](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Function-FunctionApp.png)

9. Configurer la ressource avec le bon runtime, le nom que vous souhaitez et la région
![Configurer Function](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Function-Configure.png)

10. Récupérez le Publish Profile de la Function pour pouvoir publier le code plus tard
![Get Pubish Profile](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Function-GetPublishProfile.png)

11. Allez dans Visual Studio, dans la partie Function puis dans VisionFunction.cs et insérez la clé et l'endpoint dans le code
![Configure Function](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-Function-Configure.png)

12. Faites un clic droit sur le projet et appuyez sur Publish... Ensuite, appuyez sur start et Import Profile. Cherchez après le publish profile que nous avons téléchargé plus tôt
![Import profile](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-Function-Import.png)

13. Finissez le déploiement de la fonction en appuyant sur Publish
![Publish Function](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-Function-Publish.png)

14. Testez votre Azure Function qui s'occupe de communiquer avec Computer Vision avec postman et l'adresse URL que vous trouverez sur Azure. Vous pouvez mettre une url d'image comme sur la photo
![Test Azure Function](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-Function-Test.png)

15. Dans le Ressource Group, cliquez sur le bouton Add et cherchez Storage Account et configurez le
![Storage account search](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Blob-StorageAccount.png)
![Configure storage account](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Blob-Configure.png)

16. Ensuite, allez dans Containers
![Go to Containers](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Blob-Containers.png)
Et créez un container 'pictures' en le mettant en acces level 'blob'
![Containers new](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Blob-Containers-New.png)

17. Créez une shared acces signature et configurer le avec les adresses IPs
![Shared Acces Signature New](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Blob-SharedAccess.png)

18. Mettez de côté le SAS Token pour plus tard
![SAS Token get](https://github.com/micbelgique/AzureGettingStarted/blob/master/images/Azure-CreateRessource-Blob-GetSharedAccess.png)