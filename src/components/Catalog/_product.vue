 <!-- @model CatalogItemViewModel
<form asp-page="/Basket/Index" method="post">
    <img class="esh-catalog-thumbnail" src="@Model.PictureUri" />
    <input class="esh-catalog-button" type="submit" value="[ ADD TO BASKET ]" />
    <div class="esh-catalog-name">
        <span>@Model.Name</span>
    </div>
    <div class="esh-catalog-price">
        <span>@Model.Price.ToString("N2")</span>
    </div>
    <input type="hidden" asp-for="@Model.Id" name="id" />
    <input type="hidden" asp-for="@Model.Name" name="name" />
    <input type="hidden" asp-for="@Model.PictureUri" name="pictureUri" />
    <input type="hidden" asp-for="@Model.Price" name="price" />
</form>  -->

<template>
    <div class="item">
      <i>
        <slot name="icon"></slot>
      </i>
      <div class="details">
        <h3>
          <slot name="heading"></slot>
        </h3>
        <slot></slot>
      </div>
    </div>
  </template>
