<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Customer extends Model
{
  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function phones()
  {
    return $this->belongsToMany(Phone::class, 'customers_phones');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function estimates()
  {
    return $this->hasMany(Estimate::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function customer_in()
  {
    return $this->hasOne(Vehicle::class, 'in_customer_id');
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasOne
  */
  public function contract()
  {
    return $this->hasOne(Contract::class, 'customer_id');
  }
}
