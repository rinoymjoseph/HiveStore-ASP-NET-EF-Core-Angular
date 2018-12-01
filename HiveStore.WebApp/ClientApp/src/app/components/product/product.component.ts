import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Product } from '../../models/product.model';
import { ProductService } from '../../services/product.service';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService]
})
export class ProductComponent implements OnInit {

  isLoading: boolean;
  formProduct: FormGroup;
  products: Product[];
  formdata1: FormData;
  selectedProduct: Product;

  constructor(
    private fb: FormBuilder,
    private productService: ProductService) { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(false);
    this.createProductForm();
    this.getAllProducts();
  }

  createProductForm() {
    this.formProduct = this.fb.group({
      ipProductName: [],
      ipUnitPrice: []
    });
  }

  btnSaveClick(event: any) {
    if (this.formProduct.valid) {
      this.saveProduct();
    }
  }

  btnCancelClick(event: any) {
    this.formProduct.patchValue({
      ipProductName: '',
      ipUnitPrice: ''
    });
    this.selectedProduct = null;
  }

  gridProductsOnRowSelect(event) {
    //console.log(this.selectedUser);
    this.formProduct.patchValue({
      ipProductName: this.selectedProduct.ProductName,
      ipUnitPrice: this.selectedProduct.UnitPrice
    });
  }

  getAllProducts() {
    this.isLoading = true;
    this.productService.getAllProducts().subscribe(
      (res) => {
        this.products = res;
        this.isLoading = false;
      },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  saveProduct() {
    const product: Product = new Product();
    product.Id = this.selectedProduct ? this.selectedProduct.Id : 0;
    product.ProductName = this.formProduct.value.ipProductName;
    product.UnitPrice = this.formProduct.value.ipUnitPrice;
    this.isLoading = true;
    this.productService.saveProduct(product).subscribe((res) => {
      console.log(res);
      this.isLoading = false;
      this.getAllProducts();
    },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }
}
