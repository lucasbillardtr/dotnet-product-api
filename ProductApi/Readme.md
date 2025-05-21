# Product API en C#

## Description

API REST permettant la gestion de produits et de commandes, développée en C# avec ASP.NET Core. Elle expose des endpoints CRUD pour les produits et les commandes, intègre une recherche avancée, la gestion du stock, la sécurisation par clé d'API, et la gestion des statuts de commande.

## Architecture

L'application est structurée en plusieurs dossiers principaux pour une meilleure organisation du code

- **Controllers/** : Contient les contrôleurs ASP.NET Core qui exposent les endpoints REST pour les produits, les commandes, etc.
- **Entities/** : Définit les classes représentant les entités du domaine (Product, Order, etc.), qui correspondent aux tables de la base de données.
- **Database/** : Contient le contexte Entity Framework (`DbContext`), les seeders pour l'initialisation des données, et les migrations de base de données.
- **DTOs/** : Regroupe les objets de transfert de données utilisés pour les échanges entre l’API et les clients (création, mise à jour, etc.).
- **Repositories/** : Implémente le pattern Repository pour l'accès aux données, permettant d'abstraire les opérations de lecture et d'écriture sur la base de données.
- **Services/** : Contient la logique métier, les services pour la gestion des produits et des commandes, ainsi que les validations spécifiques.
- **Extensions/** : Fournit des méthodes d’extension, par exemple pour la génération de slug ou des helpers métiers.
- **Middleware/** : Contient les middlewares personnalisés, notamment pour la gestion et la vérification de la clé d’API.
- **Program.cs / Startup.cs** : Point d’entrée de l’application et configuration des services, middlewares, etc.

Cette organisation permet de séparer clairement les responsabilités et de faciliter la maintenance et l’évolution du projet.

## Technologies utilisées

- **.NET 9**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQLite** (ou SQL Server, selon configuration)
- **Swagger/OpenAPI** (pour la documentation et le test des endpoints)
- **LINQ** (pour les opérations de recherche et de tri)
- **C# 13** (ou version compatible)

## Exercices

### 1 : CRUD Produit enrichi

**Objectif :**
Mettre en place les opérations CRUD (GET, POST, PUT, DELETE) pour les produits.

**Attendu :**
- POST et PUT utilisent un DTO sans le slug, avec surcharge d'opérateur explicite pour le mapping.
- Le slug est généré à partir du nom du produit (minuscules, tirets pour les espaces).
- Validation métier : prix strictement positif, stock >= 0.

**Conseils :**
- Utiliser une méthode d'extension pour générer le slug.

---

### 2 : Recherche avancée et reporting

**Objectif :**
Permettre la recherche avancée de produits et fournir des indicateurs de stock.

**Attendu :**
- Recherche par nom (insensible à la casse), tri par prix, pagination (offset/limit).
- Filtrer les produits disponibles (stock > 0).
- Endpoint pour obtenir le nombre total de produits en stock et la valeur totale du stock (prix * stock).

**Conseils :**
- Utiliser LINQ pour la recherche et le filtrage.
- Prévoir des endpoints dédiés pour le reporting.

---

### 3 : Sécurisation par clé d'API et gestion des droits

**Objectif :**
Sécuriser l'API avec une clé d'API et préparer la gestion de droits.

**Attendu :**
- Vérification de la clé d'API via un middleware sur chaque requête.

**Conseils :**
- Stocker la clé d'API dans la configuration.
- Retourner un code 401 en cas d'absence ou d'erreur de clé.

---

### 4 : Gestion des commandes enrichie

**Objectif :**
Gérer les commandes et leur cycle de vie.

**Attendu :**
- CRUD pour les commandes (GET, POST, PUT, DELETE).
- Une commande a un numéro, une date de création, un statut (Confirm, Send, Delivered), et une ou plusieurs lignes produit.
- Vérifier la disponibilité du stock à la création, décrémenter le stock.
- Interdire la modification d'une commande si son statut est "Send" ou "Delivered".
- Permettre de générer un rapport des commandes livrées sur une période donnée (filtrage par date et statut).

**Conseils :**
- Utiliser le pattern switch pour la gestion des statuts.
- Valider les règles métier côté service.

---

### 5 : La maitrise de LINQ

**Objectif :**
Transformer un code Java utilisant les streams en une requête LINQ C# équivalente.

**Attendu :**
- Implémenter la fonction dans `StreamToLinq.cs` du projet `SandboxConsole`.
- La méthode doit retourner le nom du projet le plus fréquent parmi les employés des départements "Engineering" ou "R&D", ayant un salaire > 70000 et embauchés après le 01/01/2020, en respectant les règles de gestion de la version Java (voir le commentaire dans le fichier).

**Conseils :**
- Utiliser les méthodes LINQ (`SelectMany`, `Where`, etc.) pour reproduire la logique du stream Java.

## Commandes utiles
### Restauration des dépendances et migrations
```bash
dotnet restore
```
### Installation de l'outil EF Core
```bash
dotnet tool install --global dotnet-ef
```
### Création des migrations
```bash
dotnet ef migrations add InitialCreate   
```
### Mise à jour de la base de données
```bash
dotnet ef database update 
```
