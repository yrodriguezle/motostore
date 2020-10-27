<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Vehicle extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasOne
  */
  public function brand()
  {
    return $this->hasOne(Brand::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasOne
  */
  public function properties()
  {
    return $this->hasOne(VehicleProperties::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function estimates()
  {
    return $this->hasMany(Estimate::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasOne
  */
  public function acquired_vehicle()
  {
    return $this->hasOne(AcquiredVehicle::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function customer_in()
  {
    return $this->belongsTo(Customer::class, 'in_customer_id');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function customer_out()
  {
    return $this->belongsTo(Customer::class, 'out_customer_id');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function user()
  {
    return $this->belongsTo(User::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function stock()
  {
    return $this->belongsToMany(Stock::class, 'stock_vehicle');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function images()
  {
    return $this->hasMany(Image::class);
  }
}
