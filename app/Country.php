<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Country extends Model
{
  protected $table = 'countries';

  /**
  * @return \Illuminate\Database\Eloquent\Relations\HasMany
  */
  public function areas()
  {
    return $this->hasMany(Area::class);
  }
}