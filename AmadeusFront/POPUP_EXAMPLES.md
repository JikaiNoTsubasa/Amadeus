# Popup System - Examples

## Utilisation du Service Popup

### 1. Injecter le Service

```typescript
import { PopupService } from './services/popup.service';
import { inject } from '@angular/core';

export class MyComponent {
  private popupService = inject(PopupService);
}
```

### 2. Popup Simple - Info/Warning/Error/Success

```typescript
// Info
showInfo() {
  this.popupService.info(
    'Information',
    'Ceci est un message d\'information.'
  );
}

// Warning
showWarning() {
  this.popupService.warning(
    'Attention',
    'Attention, cette action est risquée!'
  );
}

// Error
showError() {
  this.popupService.error(
    'Erreur',
    'Une erreur s\'est produite lors de l\'opération.'
  );
}

// Success
showSuccess() {
  this.popupService.success(
    'Succès',
    'L\'opération a été effectuée avec succès!'
  );
}
```

### 3. Popup de Confirmation

```typescript
deleteProject(projectId: number) {
  this.popupService.confirm(
    'Confirmation',
    'Êtes-vous sûr de vouloir supprimer ce projet?',
    () => {
      // Action si confirmé
      this.amaService.deleteProject(projectId).subscribe({
        next: () => {
          this.popupService.success('Succès', 'Projet supprimé!');
        },
        error: (error) => {
          this.popupService.error('Erreur', 'Impossible de supprimer le projet.');
        }
      });
    },
    () => {
      // Action si annulé (optionnel)
      console.log('Deletion cancelled');
    }
  );
}
```

### 4. Popup avec Template Personnalisé

```typescript
// Dans le component
@ViewChild('customTemplate') customTemplate!: TemplateRef<any>;

showCustomTemplate() {
  this.popupService.open({
    type: PopupType.CUSTOM,
    title: 'Formulaire Personnalisé',
    template: this.customTemplate,
    data: { name: 'John', age: 30 },
    size: PopupSize.LARGE,
    buttons: [
      {
        label: 'Annuler',
        type: 'secondary',
        action: () => {}
      },
      {
        label: 'Sauvegarder',
        type: 'primary',
        action: () => {
          console.log('Save clicked!');
        }
      }
    ]
  });
}
```

```html
<!-- Dans le template HTML -->
<ng-template #customTemplate let-data>
  <div style="padding: 20px;">
    <p>Nom: {{ data.name }}</p>
    <p>Age: {{ data.age }}</p>
    <input type="text" placeholder="Enter something..." />
  </div>
</ng-template>
```

### 5. Popup avec Composant Dynamique

Créer un composant de formulaire:

```typescript
// create-project-form.ts
@Component({
  selector: 'app-create-project-form',
  template: `
    <form>
      <div class="form-group">
        <label>Nom du projet</label>
        <input type="text" [(ngModel)]="projectName" />
      </div>
      <div class="form-group">
        <label>Description</label>
        <textarea [(ngModel)]="description"></textarea>
      </div>
    </form>
  `
})
export class CreateProjectForm {
  projectName = '';
  description = '';
}
```

Utiliser dans un popup:

```typescript
import { CreateProjectForm } from './create-project-form';

showCreateProjectForm() {
  this.popupService.open({
    type: PopupType.CUSTOM,
    title: 'Créer un Projet',
    component: CreateProjectForm,
    data: { projectName: '', description: '' },
    size: PopupSize.MEDIUM,
    buttons: [
      {
        label: 'Annuler',
        type: 'secondary',
        action: () => {}
      },
      {
        label: 'Créer',
        type: 'primary',
        action: async () => {
          // Récupérer les données du composant
          console.log('Creating project...');
        }
      }
    ]
  });
}
```

### 6. Configuration Avancée

```typescript
this.popupService.open({
  type: PopupType.CUSTOM,
  title: 'Configuration Avancée',
  message: 'Message optionnel',
  size: PopupSize.FULLSCREEN,  // SMALL | MEDIUM | LARGE | FULLSCREEN
  closeOnBackdrop: false,       // Ne pas fermer en cliquant à l'extérieur
  closeOnEscape: false,         // Ne pas fermer avec Escape
  showCloseButton: true,        // Afficher le bouton X
  buttons: [
    {
      label: 'Action 1',
      type: 'secondary',
      action: () => console.log('Action 1')
    },
    {
      label: 'Action 2',
      type: 'primary',
      action: async () => {
        // Action asynchrone
        await someAsyncOperation();
      }
    },
    {
      label: 'Danger',
      type: 'danger',
      action: () => console.log('Dangerous action')
    }
  ]
});
```

### 7. Fermer un Popup Manuellement

```typescript
// Récupérer l'ID du popup
const popupId = this.popupService.info('Info', 'Message');

// Fermer plus tard
setTimeout(() => {
  this.popupService.close(popupId);
}, 3000);

// Fermer tous les popups
this.popupService.closeAll();
```

### 8. Types de Popups Disponibles

- **INFO**: Icône bleue (information)
- **WARNING**: Icône orange (avertissement)
- **ERROR**: Icône rouge (erreur)
- **SUCCESS**: Icône verte (succès)
- **CONFIRM**: Icône bleue avec question
- **CUSTOM**: Sans icône par défaut

### 9. Tailles Disponibles

- **SMALL**: 400px
- **MEDIUM**: 600px (défaut)
- **LARGE**: 900px
- **FULLSCREEN**: 95vw x 95vh

## Exemple Complet dans MyProjects

```typescript
import { Component, inject, ViewChild, TemplateRef } from '@angular/core';
import { PopupService } from '../../services/popup.service';
import { PopupType, PopupSize } from '../../models/PopupConfig';

export class MyProjects {
  private popupService = inject(PopupService);

  @ViewChild('projectFormTemplate') projectFormTemplate!: TemplateRef<any>;

  // Exemple 1: Confirmation de suppression
  deleteProject(project: Project) {
    this.popupService.confirm(
      'Supprimer le projet',
      `Êtes-vous sûr de vouloir supprimer "${project.name}"?`,
      async () => {
        try {
          await this.amaService.deleteProject(project.id);
          this.popupService.success('Succès', 'Projet supprimé!');
          this.refreshMyProjects();
        } catch (error) {
          this.popupService.error('Erreur', 'Impossible de supprimer le projet.');
        }
      }
    );
  }

  // Exemple 2: Formulaire de création
  openCreateProjectForm() {
    this.popupService.open({
      type: PopupType.CUSTOM,
      title: 'Nouveau Projet',
      template: this.projectFormTemplate,
      size: PopupSize.MEDIUM,
      closeOnBackdrop: false,
      buttons: [
        {
          label: 'Annuler',
          type: 'secondary',
          action: () => {}
        },
        {
          label: 'Créer',
          type: 'primary',
          action: async () => {
            // Logique de création
            this.popupService.success('Succès', 'Projet créé!');
          }
        }
      ]
    });
  }
}
```

## Design System

Les popups respectent automatiquement le design system de l'application:
- **Couleurs**: Noir (#000000), Vert Lime (#B9FF66), Gris Clair (#F2F2F2)
- **Border Radius**: 10px (popups), 40px (boutons)
- **Transitions**: 0.2s ease
- **Font**: Poppins
- **Animations**: fadeIn pour le backdrop, slideIn pour le contenu
