import { Component } from '@angular/core';
import { ProductListComponent } from './features/product/product-list/product-list.component';
import { Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { EditProductComponent } from '../edit-product/edit-product.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

export const routes: Routes = [

{path: 'admin/products',component: ProductListComponent},

{path: 'admin/products/add',component: AddProductComponent},
{path: 'admin/products/edit/:id',component: EditProductComponent}

]

