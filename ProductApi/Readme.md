# Product API en C#

## 🧾 Description

API REST permettant la gestion de produits et de commandes, développée en C# avec ASP.NET Core.  
Elle expose des endpoints CRUD pour les produits et les commandes, intègre une recherche avancée, la gestion du stock,
la sécurisation par clé d’API, ainsi que la gestion des statuts de commande.

## 🏗️ Architecture

L’application est structurée en plusieurs dossiers principaux pour une meilleure organisation du code :

- **Controllers/** : Contient les contrôleurs ASP.NET Core qui exposent les endpoints REST.
- **Entities/** : Définit les entités du domaine (Product, Order, etc.), correspondant aux tables de la base de données.
- **Database/** : Contient le `DbContext`, les seeders d’initialisation des données et les migrations.
- **DTOs/** : Objets de transfert de données (Data Transfer Objects) pour les échanges API/client.
- **Repositories/** : Implémentation du pattern Repository pour l’accès aux données.
- **Services/** : Contient la logique métier (gestion produit, commande, validations).
- **Extensions/** : Méthodes d’extension (ex. : génération de slug, helpers métiers).
- **Middleware/** : Middlewares personnalisés (ex. : vérification de la clé d’API).
- **Program.cs / Startup.cs** : Point d’entrée de l’application et configuration.

Cette organisation permet une séparation claire des responsabilités, facilitant la maintenance et l’évolution du projet.

## 🧰 Technologies utilisées

- [.NET 9](https://dotnet.microsoft.com/)
- ASP.NET Core
- Entity Framework Core
- SQLite (ou SQL Server selon la configuration)
- Swagger / OpenAPI
- LINQ
- C# 13 (ou version compatible)

## 📝 Exercices

### 1️⃣ CRUD Produit enrichi

**🎯 Objectif :**  
Implémenter les opérations CRUD (GET, POST, PUT, DELETE) pour les produits.

**✅ Attendus :**

- POST et PUT utilisent un DTO sans le slug.
- Le slug est généré à partir du nom du produit (minuscules, tirets pour les espaces).
- Validation métier : prix strictement positif, stock ≥ 0.

**💡 Conseil :**  
Utiliser une méthode d’extension pour générer le slug.

---

### 2️⃣ Recherche avancée & Reporting

**🎯 Objectif :**  
Permettre la recherche avancée de produits et fournir des indicateurs de stock.

**✅ Attendus :**

- Recherche par nom (insensible à la casse), tri par prix, pagination (offset/limit).
- Filtrer les produits disponibles (stock > 0).
- Endpoint pour :
    - Nombre total de produits en stock
    - Valeur totale du stock (prix * stock)

**💡 Conseils :**

- Utiliser LINQ pour la recherche et le filtrage.
- Créer des endpoints dédiés pour le reporting.

---

### 3️⃣ Sécurisation par clé d’API et gestion des droits

**🎯 Objectif :**  
Sécuriser l’API avec une clé d’API et préparer la gestion des droits.

**✅ Attendus :**

- Vérification de la clé d’API via un middleware sur chaque requête.

**💡 Conseils :**

- Stocker la clé dans la configuration (`appsettings.json`).
- Retourner un `401 Unauthorized` en cas d’absence ou d’erreur de clé.

---

### 4️⃣ Maîtrise de LINQ

**🎯 Objectif :**  
Convertir une logique Java utilisant `streams` en une équivalence LINQ.

**✅ Attendus :**

- Implémenter la fonction dans `StreamToLinq.cs` du projet `SandboxConsole`.
- La méthode retourne le **nom du projet le plus fréquent** parmi les employés :
    - des départements "Engineering" ou "R&D"
    - avec un salaire > 70 000
    - embauchés après le 01/01/2020

**💡 Conseils :**

- Utiliser `SelectMany`, `Where`, `GroupBy`, `OrderByDescending`, etc.

---

### 5️⃣ Gestion des commandes enrichies

**🎯 Objectif :**  
Gérer les commandes et leur cycle de vie.

**✅ Attendus :**

- Une commande a un numéro, une date de création, un statut (`Confirm`, `Send`, `Delivered`, `Returned`), et une ou
  plusieurs lignes produit.
- Mise à jour du statut avec règles métier :
    - `Confirm ➜ Send` : si tous les produits sont en stock
    - ❌ `Delivered ➜ Confirm` : interdit
    - `Delivered ➜ Returned` : possible dans les 14 jours
    - ❌ Retour interdit pour les produits périssables
    - ❌ Annulation possible uniquement dans les 24h suivant la création
    -

**🟡 Optionnel :**

- Création des endpoints pour :
    - Ajouter une commande
    - Mettre à jour le statut d’une commande
    - Récupérer les commandes par statut
    - Récupérer les détails d’une commande (produits, quantités, prix)
- Rapport des commandes livrées sur une période (filtrage par date et statut).

**💡 Conseils :**

- Utiliser `switch` avec `tuple` pour les transitions de statut.
- Utiliser les `when` patterns pour ajouter des guards métier.
- Valider les règles métier dans le service avec des messages explicites.

---

## 🔧 Commandes utiles

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
