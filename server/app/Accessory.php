<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Accessory extends Model
{
  protected $table = 'accessories';

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function estimates()
  {
    return $this->belongsToMany(Estimate::class, 'estimates_accessories');
  }

  // public function rentals()
  // {
  //   return $this->belongsToMany('App\Rental', 'rentals_accessories', 'accessory_id', 'rental_id');
  // }

  // public function contracts()
  // {
  //   return $this->belongsToMany('App\Contract', 'contracts_accessories', 'accessory_id', 'contract_id');
  // }

}
