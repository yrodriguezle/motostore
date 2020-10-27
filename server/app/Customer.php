<?php

namespace App;
use Illuminate\Support\Arr;
use Illuminate\Support\Facades\DB;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsToMany;
use Illuminate\Database\Eloquent\Builder;

class Customer extends Model
{
  public function scopeSearch(Builder $query, $args): Builder
  {
    $search = Arr::exists($args, 'search') ? $args['search'] : null;

    if ($search) {
      $parts = explode(" ", trim(preg_replace('/\s+/', ' ', str_replace("\n", " ", $search))));
      return $query
        ->where(DB::raw("CONCAT(`first_name`, ' ', `last_name`)"), 'like', "%$search%")
        ->orWhere('first_name', 'like', "%$search%")
        ->orWhere('last_name', 'like', "%$search%")
        ->orWhere('fiscal_code', 'like', "%$search%")
        ->orWhere('address', 'like', "%$search%")
        ->orWhere('location', 'like', "%$search%")
        ->orWhere('city', 'like', "%$search%")
        ->orWhere('province', 'like', "%$search%")
        ->orWhere('license_number', 'like', "%$search%")
        ->orWhere(function($query) use ($parts) {
          foreach ($parts as $part) {
            $query
              ->where('first_name', 'like', "%$part%")
              ->orWhere('last_name', 'like', "%$part%")
              ->orWhere('fiscal_code', 'like', "%$part%")
              ->orWhere('address', 'like', "%$part%")
              ->orWhere('location', 'like', "%$part%")
              ->orWhere('city', 'like', "%$part%")
              ->orWhere('province', 'like', "%$part%")
              ->orWhere('license_number', 'like', "%$part%");
          }
        });
    }
    return $query;
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany
  */
  public function phones(): BelongsToMany
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
  * @return \Illuminate\Database\Eloquent\Relations\HasOne
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
