import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductService } from '../features/services/product.service';
import { Product } from '../features/models/product.model';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
  imports: [ReactiveFormsModule],
  standalone:true
})
export class AddProductComponent {
  productForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern('')]],
      description: ['']
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const newProduct: Product = this.productForm.value;
      this.productService.addProduct(newProduct).subscribe({
        next: (response) => {
          this.toastr.success('Product added successfully');
          this.productForm.reset();
          this.router.navigate(['/admin/products']);
        },
        error: (err) => {
          this.toastr.error('Error adding product');
          console.error('Error adding product', err);
        }
      });
    }
  }
}
