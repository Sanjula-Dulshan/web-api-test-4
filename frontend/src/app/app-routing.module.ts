import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/external',
    pathMatch: 'full',
  },
  {
    path: 'internal',
    loadChildren: () =>
      import('./internal/internal.module').then((m) => m.InternalModule),
  },
  {
    path: 'external',
    loadChildren: () =>
      import('./external/external.module').then((m) => m.ExternalModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
