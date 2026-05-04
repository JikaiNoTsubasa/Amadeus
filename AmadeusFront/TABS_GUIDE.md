# Guide des Tabs dans ProjectDetailView

## Vue d'ensemble

Le système de tabs dans ProjectDetailView utilise un composant **TabNav** compact et léger qui ne prend pas beaucoup de place. La navigation se fait avec un simple underline sur le tab actif.

## ✨ Persistance de l'État

Le tab actif est **automatiquement sauvegardé** dans le localStorage pour chaque projet:
- Chaque projet a son propre tab actif sauvegardé
- Quand vous revenez sur un projet, vous retrouvez le dernier tab consulté
- La sauvegarde est isolée par browser tab (utilise le StorageService)

## Structure Actuelle

### Tabs par défaut:
1. **Overview** (fa-info-circle) - Informations de base du projet
2. **Tasks** (fa-tasks) - Liste des tâches du projet

## Comment Ajouter un Nouveau Tab

### Étape 1: Créer le composant de contenu (optionnel si simple)

Si vous avez besoin d'un nouveau composant pour votre tab:

```bash
mkdir -p src/app/comps/project-phases-list
```

Créez votre composant:

```typescript
// project-phases-list.ts
import { Component, Input } from '@angular/core';
import { Project } from '../../models/Project';

@Component({
  selector: 'app-project-phases-list',
  imports: [],
  templateUrl: './project-phases-list.html',
  styleUrl: './project-phases-list.scss',
})
export class ProjectPhasesList {
  @Input() project!: Project;

  ngOnInit() {
    // Charger les phases du projet
  }
}
```

### Étape 2: Ajouter le tab dans ProjectDetailView

**Fichier:** `src/app/comps/project-detail-view/project-detail-view.ts`

#### 2.1 Importer votre composant

```typescript
import { ProjectPhasesList } from '../project-phases-list/project-phases-list';

@Component({
  selector: 'app-project-detail-view',
  imports: [DatePipe, TabNav, ProjectTasksList, ProjectPhasesList], // ← Ajouter ici
  // ...
})
```

#### 2.2 Ajouter le tab dans le tableau `tabs`

```typescript
tabs: NavTab[] = [
  { id: 'overview', label: 'Overview', icon: 'fa-info-circle' },
  { id: 'tasks', label: 'Tasks', icon: 'fa-tasks' },
  { id: 'phases', label: 'Phases', icon: 'fa-list' }, // ← Nouveau tab
];
```

### Étape 3: Ajouter le contenu dans le template

**Fichier:** `src/app/comps/project-detail-view/project-detail-view.html`

Décommenter et ajouter votre section:

```html
@if (activeTabId === 'phases') {
  <app-project-phases-list [project]="project"></app-project-phases-list>
}
```

## Exemple Complet: Ajouter un Tab "Files"

### 1. Dans `project-detail-view.ts`:

```typescript
import { ProjectFilesList } from '../project-files-list/project-files-list';

@Component({
  selector: 'app-project-detail-view',
  imports: [
    DatePipe,
    TabNav,
    ProjectTasksList,
    ProjectFilesList  // ← Ajouté
  ],
  templateUrl: './project-detail-view.html',
  styleUrl: './project-detail-view.scss',
})
export class ProjectDetailView {
  @Input() project!: Project;

  activeTabId: string = 'overview';

  tabs: NavTab[] = [
    { id: 'overview', label: 'Overview', icon: 'fa-info-circle' },
    { id: 'tasks', label: 'Tasks', icon: 'fa-tasks' },
    { id: 'files', label: 'Files', icon: 'fa-file' }  // ← Ajouté
  ];

  onTabChange(tabId: string): void {
    this.activeTabId = tabId;
  }
}
```

### 2. Dans `project-detail-view.html`:

```html
@if (activeTabId === 'files') {
  <app-project-files-list [project]="project"></app-project-files-list>
}
```

## Tab Simple Sans Composant

Si votre contenu est simple, vous n'avez pas besoin de créer un composant séparé:

### Dans `project-detail-view.ts`:

```typescript
tabs: NavTab[] = [
  { id: 'overview', label: 'Overview', icon: 'fa-info-circle' },
  { id: 'tasks', label: 'Tasks', icon: 'fa-tasks' },
  { id: 'notes', label: 'Notes', icon: 'fa-sticky-note' }  // ← Simple tab
];
```

### Dans `project-detail-view.html`:

```html
@if (activeTabId === 'notes') {
  <div class="detail-section">
    <h2 class="section-title">Project Notes</h2>
    <textarea
      class="notes-input"
      placeholder="Add your notes here..."
      [(ngModel)]="projectNotes">
    </textarea>
  </div>
}
```

## Icônes Font Awesome Disponibles

Quelques icônes utiles pour vos tabs:

- `fa-info-circle` - Informations
- `fa-tasks` - Tâches
- `fa-list` - Liste/Phases
- `fa-file` - Fichiers
- `fa-users` - Équipe
- `fa-calendar` - Planning
- `fa-chart-line` - Statistiques
- `fa-comments` - Discussions
- `fa-sticky-note` - Notes
- `fa-cog` - Paramètres
- `fa-history` - Historique

## Style des Tabs

Le composant TabNav utilise un design minimaliste:

- **Tabs inactifs**: Gris, opacité 60%
- **Hover**: Opacité 100%, couleur vert lime
- **Tab actif**: Noir, opacité 100%, underline vert lime
- **Hauteur**: Compact, seulement 40px environ
- **Border**: Fine ligne en bas pour séparer

Pas besoin de modifier les styles, tout est géré automatiquement!

## Persistance Automatique

Le système sauvegarde automatiquement le tab actif pour chaque projet:

### Comment ça marche

1. **Sauvegarde**: Quand vous changez de tab, l'état est sauvegardé dans localStorage
2. **Clé unique**: Chaque projet a sa propre clé: `project_detail_activeTab_${projectId}`
3. **Restauration**: Au chargement du projet, le dernier tab consulté est réactivé
4. **Fallback**: Si le tab sauvegardé n'existe plus, retour au tab "overview"

### Exemple de flux

```
1. User ouvre Projet A → Tab "overview" (défaut)
2. User clique sur tab "tasks" → Sauvegarde: activeTab_123 = "tasks"
3. User change de projet ou ferme l'onglet
4. User rouvre Projet A → Restaure automatiquement tab "tasks"
```

### Isolation

- Chaque browser tab a son propre état (utilise le système de tabId)
- Les tabs de différents projets ne s'interfèrent pas
- Format de stockage: `{tabId}_project_detail_activeTab_{projectId}`

## Conseils

1. **Ordre des tabs**: Mettez les tabs les plus utilisés en premier
2. **Labels courts**: Gardez les labels courts (1-2 mots)
3. **Icônes**: Utilisez toujours une icône pour plus de clarté
4. **Lazy loading**: Les composants ne sont chargés que quand le tab est activé
5. **Données**: Passez toujours `[project]="project"` aux composants enfants
6. **Persistance**: Le tab actif est sauvegardé automatiquement, rien à faire!

## Résumé: 3 Étapes Faciles

1. **Créer le composant** (ou utiliser du HTML simple)
2. **Ajouter dans `tabs[]`** avec id, label, icon
3. **Ajouter `@if (activeTabId === 'votre-id')` dans le template**

C'est tout! 🚀
