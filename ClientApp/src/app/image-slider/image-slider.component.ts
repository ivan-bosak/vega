import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-image-slider',
  templateUrl: './image-slider.component.html',
  styleUrls: ['./image-slider.component.css']
})
export class ImageSliderComponent implements OnInit {

  @Input() images: any[];
  slideIndex: number;
  constructor() { 
    this.slideIndex = 0;
  }

  ngOnInit() {
  }

  plusSlides(n) {
    var slide = document.getElementById("image" + this.slideIndex);
    slide.style.display = "none";
  
    if(n == -1 && this.slideIndex == 0){
      this.slideIndex = this.images.length - 1;
    }
    else if(n == 1 && this.slideIndex == this.images.length - 1){
      this.slideIndex = 0;
    }
    else {
      this.slideIndex = this.slideIndex + n;
    }
    var slide = document.getElementById("image" + this.slideIndex);
    slide.style.display = "block";
  }

}
