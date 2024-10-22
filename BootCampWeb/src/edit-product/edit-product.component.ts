import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../app/features/services/product.service';
import { Product } from '../app/features/models/product.model';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css'],
  imports: [ReactiveFormsModule],
  standalone: true
})
export class EditProductComponent implements OnInit {
  productForm: FormGroup;
  productId: string | null;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: ['', Validators.required],
      description: ['', Validators.required]
    });
    this.productId = this.route.snapshot.paramMap.get('id');
  }

  ngOnInit(): void {
    if (this.productId) {
      this.productService.getProductById(this.productId).subscribe({
        next: (product: Product) => {
          this.productForm.patchValue({
            name: product.name,
            price: product.price,
            description: product.description
          });
        },
        error: (err) => {
          this.toastr.error('Error loading product');
          console.error('Error loading product', err);
        }
      });
    }
  }

  onSubmit(): void {
    if (this.productForm.valid && this.productId) {
      const updatedProduct: Product = this.productForm.value;
      updatedProduct.id = this.productId;
      console.log('Updated Product:', updatedProduct);
      this.productService.updateProduct(this.productId, updatedProduct).subscribe({
        next: (response) => {
          this.toastr.info('Product updated successfully');
          console.log('Product updated successfully', response);
          this.router.navigate(['/admin/products']);
        },
        error: (err) => {
          this.toastr.error('Error updating product');
          console.error('Error updating product', err);
        }
      });
    }
  }
}
