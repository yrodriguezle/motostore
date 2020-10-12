<?php

namespace App;
use Illuminate\Database\Eloquent\Model;

class Financing extends Model
{
  protected $table = 'financing';

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function user()
  {
    return $this->belongsTo(User::class);
  }

  /**
  * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
  */
  public function userApprovazione()
  {
    return $this->belongsTo(User::class, 'user_id_approvazione');
  }
}
