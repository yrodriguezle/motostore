<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Complete extends Model
{
  protected $table = 'complete';

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
  public function contracts()
  {
    return $this->belongsToMany(Contract::class, 'contract_complete');
  }
}
